using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 _moveDestination;
    [SerializeField] private float _movementSpeed;
    public Vector2 MovementDestination { set { _moveDestination = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _moveDestination = new Vector2(0, -10);
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveDestination, _movementSpeed * Time.deltaTime);
    }
}
