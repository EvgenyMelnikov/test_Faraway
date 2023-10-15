using System.Linq;
using UnityEngine;

/// <summary>
/// Класс управляет персонажем в режиме бега
/// </summary>
public class MovementSystem : ISystem
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Entity _owner;
    
    private static readonly int IsMove = Animator.StringToHash("isRun");
    
    public void OnInit(Entity owner)
    {
        _owner = owner;
        var view = owner.GetComponent<PlayerView>();
        _animator = view.Animator;
        _rigidbody2D = view.GetComponent<Rigidbody2D>();
        
        _animator.SetBool(IsMove, true);
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
        _rigidbody2D.velocity = Vector2.zero;
        _animator.SetBool(IsMove, false);
    }
}