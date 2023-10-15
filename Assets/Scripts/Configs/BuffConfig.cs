using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

/// <summary>
/// Хранит настройки накладываемых эффектов.
/// </summary>
[CreateAssetMenu(fileName = "BuffConfig", menuName = "ScriptableObjects/BuffConfig", order = 1)]
public class BuffConfig : ScriptableObjectInstaller
{
    [SerializeReference, SubclassSelector] private List<BaseBuff> _buffs;

    public T Get<T>() where T : BaseBuff
    {
        return (T)_buffs.FirstOrDefault(x => x is T);
    }
    
    public BaseBuff GetRandom()
    {
        return _buffs.OrderBy(x => Guid.NewGuid()).First();
    }
    
    public override void InstallBindings()
    {
        Container.Bind<BuffConfig>().FromInstance(this).AsSingle();
    }
}