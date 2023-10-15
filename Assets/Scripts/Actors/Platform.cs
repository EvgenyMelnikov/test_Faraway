using UnityEngine;

/// <summary>
/// Класс сущьности платформы. Контроллер для view платформы
/// </summary>
public class Platform : Actor
{
    private readonly PlatformView _view;
    public override Transform Transform { get; }
    
    public Platform(PlatformView view)
    {
        _view = view;
        Transform = view.transform;
    }
    
    public override void Dispose()
    {
        Object.Destroy(_view.gameObject);
    }
}