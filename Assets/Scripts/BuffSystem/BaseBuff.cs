using System;

/// <summary>
/// Базовый класс накладываемого эффекта
/// </summary>
[Serializable]
public abstract class BaseBuff : IDisposable
{
    public float Duration;

    public abstract void Init(Entity target);
    
    public abstract void Dispose();
}