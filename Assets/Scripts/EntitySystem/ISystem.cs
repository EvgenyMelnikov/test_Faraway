/// <summary>
/// Маркер системы для системы Entity
/// </summary>
public interface ISystem
{
    public void OnInit(Entity owner);
    public void OnUpdate(float deltaTime);
    public void OnDispose();
}