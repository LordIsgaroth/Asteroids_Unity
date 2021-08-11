using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{    
    [SerializeField] protected float _score;    

    UnityEvent<GameObject, Collider2D> _enemyCollisionEvent = new UnityEvent<GameObject, Collider2D>();
    public UnityEvent<GameObject, Collider2D> EnemyCollisionEvent { get => _enemyCollisionEvent; }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemyCollisionEvent.Invoke(gameObject, collision);
    }
}
