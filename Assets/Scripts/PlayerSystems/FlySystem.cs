using System.Linq;
using UnityEngine;

/// <summary>
/// Класс управляет персонажем в режиме полета
/// </summary>
public class FlySystem : ISystem
{
    private Rigidbody2D _rigidbody2D;
    private Entity _owner;

    private float _time;
    
    public void OnInit(Entity owner)
    {
        _owner = owner;
        _rigidbody2D = owner.GetComponent<PlayerView>().GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.AddForce(Vector2.up * 20);
    }

    public void OnUpdate(float deltaTime)
    {
        var components = _owner.GetComponents<SpeedComponent>();
        
        if (components == null)
            return;
        
        var speed = components.Sum(x => x.Value);
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }

    public void OnDispose()
    {
        _rigidbody2D.gravityScale = 1;
    }
}