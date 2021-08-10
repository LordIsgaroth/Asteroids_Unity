using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    protected Vector2 _movementDestination = new Vector2();
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _score;

    UnityEvent<GameObject, Collider2D> _enemyCollisionEvent = new UnityEvent<GameObject, Collider2D>();
    public UnityEvent<GameObject, Collider2D> EnemyCollisionEvent { get => _enemyCollisionEvent; }

    private void Update()
    {        
        transform.position = Vector2.MoveTowards(transform.position, _movementDestination, _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemyCollisionEvent.Invoke(gameObject, collision);
    }
}
