using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Класс сущьности игрока. Контроллер для view игрока
/// </summary>
public class Player : Actor, IManualUpdate
{
    public override Transform Transform { get; }

    private readonly PlayerView _view;
    private readonly Entity _entity;

    public Player(PlayerView view)
    {
        _view = view;
        Transform = view.transform;

        _entity = new Entity();
        _entity.SetComponent(new SpeedComponent{Value = 3});
        _entity.SetComponent(view);
        
        _entity.SetSystem(new BuffSystem());
        _entity.SetSystem(new MovementSystem());
    }
    
    public T GetSystem<T>() where T : ISystem
    {
        return _entity.GetSystem<T>();
    }
    
    public override void Dispose()
    {
        if (_view != null)
            Object.Destroy(_view.gameObject);
    }

    public void ManualUpdate(float deltaTime)
    {
        _entity.Update(deltaTime);
    }
}