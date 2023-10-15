using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Базовый класс сложной сушьности.
/// Хранит компоненты и системы, управляющие сущьностью.
/// Предоставляет интерфейс изменеия систем и сущьностей в процессе исполнения.
/// Управляет жизненыим циклом систем.
/// </summary>
public class Entity
{
    protected readonly List<IComponent> Components = new();
    protected readonly List<ISystem> Systems = new();

    public void SetComponent<T>(T component) where T : IComponent
    {
        Components.Add(component);
    }

    public T GetComponent<T>() where T : IComponent
    {
        return (T)Components.FirstOrDefault(x => x is T);
    }
    
    public IEnumerable<T> GetComponents<T>() where T : IComponent
    {
        return Components.OfType<T>();
    }

    public void RemoveComponent<T>(T component) where T : IComponent
    {
        Components.Remove(component);
    }
        
    public void SetSystem<T>(T component) where T : ISystem
    {
        component.OnInit(this);
        Systems.Add(component);
    }

    public T GetSystem<T>() where T : ISystem
    {
        return (T)Systems.FirstOrDefault(x => x is T);
    }

    public void RemoveSystem<T>(T component) where T : ISystem
    {
        component.OnDispose();
        Systems.Remove(component);
    }
    
    public void Update(float deltaTime)
    {
        foreach (var system in Systems.ToList())
            system.OnUpdate(deltaTime);
    }
}