using UnityEngine;
using Zenject;

public interface IManualUpdate
{
    public void ManualUpdate(float deltaTime);
}

/// <summary>
/// Класс нужен для того, чтобы можно было замедлить мир без изпользования timeScale.
/// Все обьеткы, реализующие ManualUpdate будут получать модифицированный deltaTime
/// </summary>
public class ManualUpdateSystem : ITickable
{
    public float Factor = 1;
    
    private readonly IWorld _world;

    public ManualUpdateSystem(IWorld world)
    {
        _world = world;
    }
    
    public void Tick()
    {
        var deltaTime = Time.deltaTime * Factor;
        
        foreach (var actor in _world.GetActors<IManualUpdate>())
            actor.ManualUpdate(deltaTime);
    }
}