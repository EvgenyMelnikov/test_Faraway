using System;
using System.Linq;
using UnityEngine;
using Zenject;

/// <summary>
/// Класс контролирует создание и удаление монеток.
/// </summary>
public class CoinsController : IInitializable, IDisposable, ITickable
{
    private readonly IWorld _world;
    private readonly SignalBus _signalBus;
    private readonly LocationPlaceholder _locationPlaceholder;
    private readonly BuffConfig _config;

    private Coin _coin;

    public CoinsController(IWorld world, SignalBus signalBus, LocationPlaceholder locationPlaceholder, BuffConfig config)
    {
        _world = world;
        _signalBus = signalBus;
        _locationPlaceholder = locationPlaceholder;
        _config = config;
    }
    
    public void Initialize()
    {
        _signalBus.Subscribe<CoinContactSignal>(OnContact);
    }

    public void Dispose()
    {
        _signalBus.TryUnsubscribe<CoinContactSignal>(OnContact);
    }

    private void OnContact(CoinContactSignal obj)
    {
        _world.RemoveActor(_coin);

        _coin = null;
        
        var player = _world.GetActors<Player>().FirstOrDefault();
        player?.GetSystem<BuffSystem>().Add(_config.GetRandom());
    }

    public void Tick()
    {
        if (_coin != null)
            return;

        var player = _world.GetActors<Player>().FirstOrDefault();
        
        if (player == null)
            return;
        
        if (player.GetSystem<BuffSystem>().Buffs.Count > 0)
            return;
        
        _coin = _world.CreateActor<Coin>();
        _coin.Transform.SetParent(_locationPlaceholder.Container);
        _coin.Transform.localPosition = new Vector3(_locationPlaceholder.RightBorder, 1f);
    }
}