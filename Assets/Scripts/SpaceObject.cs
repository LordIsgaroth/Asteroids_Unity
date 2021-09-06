using Movement;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Космический объект
/// </summary>
[RequireComponent(typeof(MovementView))]
public class SpaceObject : MonoBehaviour
{    
    [SerializeField] protected int _score;
    [SerializeField] protected float _movementSpeed;

    protected MovementView _movementView;

    protected UnityEvent<SpaceObject, Collider2D> _enemyCollisionEvent = new UnityEvent<SpaceObject, Collider2D>();
    public UnityEvent<SpaceObject, Collider2D> EnemyCollisionEvent { get => _enemyCollisionEvent; }

    public int Score { get => _score; }

    protected void Awake()
    {
        _movementView = GetComponent<MovementView>();
        _movementView.MovementSpeed = _movementSpeed;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemyCollisionEvent.Invoke(this, collision);
    }
}
