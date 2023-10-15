using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

/// <summary>
/// Класс управляет локацией.
/// Перемещает обьекты отностиельно позиции персонажа.
/// Так же перемещает персонада в центр экрана каджый кадр для реализации бесконечного движения
/// </summary>
public class LocationController : ILateTickable, IInitializable
{
    private readonly LocationPlaceholder _placeholder;
    private readonly IWorld _world;

    private readonly List<Transform> _platforms = new();

    public LocationController(LocationPlaceholder placeholder, IWorld world)
    {
        _placeholder = placeholder;
        _world = world;
    }
    
    public void Initialize()
    {
        var platform = _world.CreateActor<Platform>().Transform;
        platform.SetParent( _placeholder.Container);
        platform.localPosition = new Vector3(0, 0, 0);
        _platforms.Add(platform);
        
        var itemSize = platform.GetComponent<BoxCollider2D>().size;
        var count = _placeholder.Size.x / itemSize.x + 2;
        
        for (var i = 1; i < count; i++)
        {
            var tr = _world.CreateActor<Platform>().Transform;
            tr.SetParent( _placeholder.Container);
            tr.localPosition = new Vector3(itemSize.x * -i, 0, 0);
            _platforms.Add(tr);
        }
    }

    public void LateTick()
    {
        if (_platforms.Count == 0)
            return;
        
        var player = _world.GetActors<Player>().FirstOrDefault();
        
        if (player == null)
            return;

        var delta = player.Transform.position.x * Vector3.right;
        
        foreach (var actor in _world.GetActors<Actor>())
            actor.Transform.localPosition -= delta;
        
        player.Transform.SetPositionX(0);
        
        if (_platforms[^1].position.x < _placeholder.LeftBorder)
        {
            var item = _platforms[^1];
            _platforms.RemoveAt(_platforms.Count - 1);
            var pos = _platforms[0].transform.localPosition;
            pos.x += item.GetComponent<BoxCollider2D>().size.x;
            item.transform.localPosition = pos;
            _platforms.Insert(0, item);
        }
    }
}