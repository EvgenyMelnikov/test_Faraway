using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public interface IWorld
{
    public T CreateActor<T>()  where T : Actor;
    public void RemoveActor(Actor actor);
    public IEnumerable<T> GetActors<T>();
}

/// <summary>
/// Класс агрегатор сушьностей игры.
/// Упрвляет созданием и удалением обьектов. Предоставляет быстрый доступ к обьектам.
/// </summary>
public class World : IWorld
{
    private readonly DiContainer _container;
    
    private readonly List<Actor> _actors = new ();

    public World(DiContainer container)
    {
        _container = container;
    }

    public T CreateActor<T>() where T : Actor
    {
        var instance = _container.Instantiate<T>();
        _actors.Add(instance);
        return instance;
    }

    public void RemoveActor(Actor actor)
    {
        _actors.Remove(actor);
        actor.Dispose();
    }

    public IEnumerable<T> GetActors<T>()
    {
        return _actors.OfType<T>();
    }
}

public abstract class Actor : IDisposable
{
    public abstract Transform Transform { get;}
    public abstract void Dispose();
}