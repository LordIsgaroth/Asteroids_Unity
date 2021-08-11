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
                if (_currentSpeed < _movementSpeed) _currentSpeed += _acceleration;
                else if (_currentSpeed > _movementSpeed) _currentSpeed = _movementSpeed;
            }
        }
    }
}
