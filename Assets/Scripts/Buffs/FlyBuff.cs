using System;

/// <summary>
/// Эффект, меняющий поведение персонажа на полет
/// Заменяет систему движения на время жизни. По окончании возвращает заменную систему на место
/// </summary>
[Serializable]
public class FlyBuff : BaseBuff
{
    private Entity _target;
    private FlySystem _system;
    private MovementSystem _defaultSystem;
    
    public override void Init(Entity target)
    {
        _target = target;
        _defaultSystem = _target.GetSystem<MovementSystem>();
        _system = new FlySystem();
        _target.RemoveSystem(_defaultSystem);
        _target.SetSystem(_system);
    }

    public override void Dispose()
    {
        _target.RemoveSystem(_system);
        _target.SetSystem(_defaultSystem);
    }
}