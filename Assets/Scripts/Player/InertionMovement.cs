using UnityEngine;

public class InertionMovement : MonoBehaviour
{
    private float _rotateDirection;
    [SerializeField] private float _maxSpeed;
    private float _currentSpeed;
    [SerializeField] private float _rotationSpeed;
    private float _inertion = 0.015f;
    private float _acceleration = 0.05f;
    private bool _accelerated = false;

    public bool Accelerated { set { _accelerated = value; } }
    public float RotateDirection { set { _rotateDirection = value; } }

    void Start()
    {        
        _rotateDirection = 0;
        _currentSpeed = 0;
    }

    void Update()
    {
        transform.Translate(Vector2.up * _currentSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 45) * _rotateDirection * _rotationSpeed * Time.deltaTime);                       
    }

    private void FixedUpdate()
    {
        Accelerate();
        Inertion();
    }

    private void Inertion()
    {
        if (_currentSpeed > 0) _currentSpeed -= _inertion;
        else if (_currentSpeed < 0) _currentSpeed = 0;
    }

    private void Accelerate()
    {
        if (_accelerated)
        {
            if (_currentSpeed < _maxSpeed) _currentSpeed += _acceleration;
            else if (_currentSpeed > _maxSpeed) _currentSpeed = _maxSpeed;
        }
    }
}
