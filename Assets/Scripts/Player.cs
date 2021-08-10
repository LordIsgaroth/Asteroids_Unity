using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{    
    private Vector2 _moveAxis;
    private float _rotateDirection;
    [SerializeField] private float _maxSpeed;
    private float _currentSpeed;
    [SerializeField] private float _rotationSpeed;
    private float _inertion = 0.015f;
    private float _acceleration = 0.05f;
    private bool _accelerated = false;
    [SerializeField] private Shooting _shootingController;
    private GameObject _mainProjectile;    
  
    void Start()
    {        
        _mainProjectile = Shooting.GetProjectileByName("PlasmaBolt");

        _moveAxis = new Vector2(0, 1);
        _rotateDirection = 0;
        //_maxSpeed = 2f;
        _currentSpeed = 0;
        //_rotationSpeed = 2f;
    }
    
    void Update()
    {
        transform.Translate(_moveAxis * _currentSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 45) * _rotateDirection * _rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //Инерция
        if (_currentSpeed > 0) _currentSpeed -= _inertion;
        else if (_currentSpeed < 0) _currentSpeed = 0;

        Accelerate();

    }

    private void Accelerate()
    {
        if(_accelerated)
        {
            if (_currentSpeed < _maxSpeed) _currentSpeed += _acceleration;
            else if (_currentSpeed > _maxSpeed) _currentSpeed = _maxSpeed;
        }                
    }

    public void OnMove(InputAction.CallbackContext context)
    {        
        _accelerated = !context.canceled;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _rotateDirection = -context.ReadValue<Vector2>().x;
    }

    public void OnFireMain(InputAction.CallbackContext context)
    {
        _shootingController.Shoot(_mainProjectile);        
    }
}
