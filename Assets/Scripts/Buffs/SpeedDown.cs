using System;
using UnityEngine;

/// <summary>
/// Эффект, замедляюший порснажа
/// Добавляет дополнительный компонент скорости, который будет суммирован с исходным
/// </summary>
[Serializable]
public class SpeedDown : BaseBuff
{
    [SerializeField] private float _additionalSpeed = 2;
    
    private Entity _target;

    private SpeedComponent _component;
    
    public override void Init(Entity target)
    {
        _component = new SpeedComponent { Value = -_additionalSpeed };
        _target = target;
        _target.SetComponent(_component);
    }

    public override void Dispose()
    {
        _target.RemoveComponent(_component);
    }
}