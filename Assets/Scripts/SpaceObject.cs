using UnityEngine;
using UnityEngine.Events;

public class SpaceObject : MonoBehaviour
{    
    [SerializeField] protected int _score;

    public int Score { get => _score; }

    UnityEvent<SpaceObject, Collider2D> _enemyCollisionEvent = new UnityEvent<SpaceObject, Collider2D>();
    public UnityEvent<SpaceObject, Collider2D> EnemyCollisionEvent { get => _enemyCollisionEvent; }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemyCollisionEvent.Invoke(this, collision);
    }
}
