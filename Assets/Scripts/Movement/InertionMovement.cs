using UnityEngine;

namespace Movement
{
    public class InertionMovement : Movement
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _inertion;
        [SerializeField] private float _acceleration;

        private float _rotateDirection;        
        private float _currentSpeed;        
        private bool _accelerated = false;
        private Vector2 _movementDirection;
        private Vector2 _accelerationDirection;

        public bool Accelerated { set { _accelerated = value; } }
        public float RotateDirection { set { _rotateDirection = value; } }

        public float CurrentSpeed { get => _currentSpeed; }

        void Start()
        {
            _movementDirection = transform.up;
            _accelerationDirection = transform.up;
            _rotateDirection = 0;
            _currentSpeed = 0;
        }

        void Update()
        {
            transform.Translate(_movementDirection * _currentSpeed * Time.deltaTime);
            Rotate();
        }

        private void FixedUpdate()
        {
            Accelerate();
            Inertion();
        }

        private void Rotate()
        {
            transform.Rotate(new Vector3(0, 0, 45) * _rotateDirection * _rotationSpeed * Time.deltaTime);
            _movementDirection = Vector2.Lerp(_movementDirection, _accelerationDirection, Time.deltaTime);            
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
                _accelerationDirection = transform.up;
                _movementDirection = Vector2.up;

                if (_currentSpeed < _movementSpeed) _currentSpeed += _acceleration;
                else if (_currentSpeed > _movementSpeed) _currentSpeed = _movementSpeed;                
            }
        }
    }
}
