using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Vector2 _movementDestination = new Vector2();
    [SerializeField] protected float _movementSpeed;

    private void Update()
    {        
        transform.position = Vector2.MoveTowards(transform.position, _movementDestination, _movementSpeed * Time.deltaTime);
    }
}
