using System;
using Zenject;

/// <summary>
/// Класс проводит начальную инициализацию базовых игровых обьектов
/// </summary>
public class Bootstrap : IInitializable, IDisposable
{
    private readonly IWorld _world;

    private Player _player;

    public Bootstrap(IWorld world)
    {
        _world = world;
    }
    
    public void Initialize()
    {
        _player = _world.CreateActor<Player>();
    }

    public void Dispose()
    {
        _world.RemoveActor(_player);
    }
}