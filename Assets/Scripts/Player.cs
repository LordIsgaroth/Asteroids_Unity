using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Vector2 _moveAxis;
    private float _speed;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _moveAxis = new Vector2();
        _speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        _rigidBody.velocity = _moveAxis * _speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveAxis = context.ReadValue<Vector2>();

        Debug.Log(_moveAxis);
    }
}
