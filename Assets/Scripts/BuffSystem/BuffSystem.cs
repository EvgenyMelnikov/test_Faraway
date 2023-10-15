using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Класс управляет накладываемыми эффектам.
/// В частности ведет отсчет времени и удаляет эффект при его истечении
/// Хранит все текущие эффекты.
/// </summary>
public class BuffSystem : ISystem
{
    public readonly Dictionary<BaseBuff, float> Buffs = new();

    private Entity _owner;
    
    public void OnInit(Entity owner)
    {
        _owner = owner;
    }

    public void OnUpdate(float deltaTime)
    {
        foreach (var key in Buffs.Keys.ToList())
        {
            Buffs[key] -= deltaTime;
            
            if (Buffs[key] >= 0)
                return;
            
            Buffs.Remove(key);
            key.Dispose();
        }
    }

    public void OnDispose()
    {
        foreach (var key in Buffs.Keys)
            key.Dispose();
        
        Buffs.Clear();
    }
    
    public void Add(BaseBuff buff)
    {
        Buffs[buff] = buff.Duration;
        buff.Init(_owner);
    }
}