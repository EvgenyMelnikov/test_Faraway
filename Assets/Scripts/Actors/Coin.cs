using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

/// <summary>
/// Класс сущьности монетки. Контроллер для view монетки
/// </summary>
public class Coin : Actor, IDisposable
{
    private readonly CoinView _view;
    private readonly SignalBus _signalBus;
    
    public override Transform Transform { get; }

    public Coin(CoinView view, SignalBus signalBus)
    {
        _view = view;
        _signalBus = signalBus;
        Transform = view.transform;
        
        _view.Contact += OnContact;
    }
    
    public override void Dispose()
    {
        _view.Contact -= OnContact;
        
        Object.Destroy(_view.gameObject);
    }
    
    private void OnContact(PlayerView obj)
    {
        _signalBus.Fire(new CoinContactSignal { Coin = this });
    }
}