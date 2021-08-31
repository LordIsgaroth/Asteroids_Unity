using UnityEngine;
using UnityEngine.Events;

namespace Movement
{
    public class InertionMovementModel
    {
        private float _accelerationValue;
        private float _inertionValue;
        private float _maxSpeed;
        private float _currentSpeed;
        private Vector2 _movementDirection;
        private Transform _transform;

        public float CurrentSpeed => _currentSpeed;
        public Vector2 MovementDirection => _movementDirection;

        public UnityEvent<float, Vector2> MovementUpdated = new UnityEvent<float, Vector2>();

        public InertionMovementModel(float accelerationValue, float inertionValue, float maxSpeed, Transform transform)
        {
            _accelerationValue = accelerationValue;
            _inertionValue = inertionValue;
            _maxSpeed = maxSpeed;
            _currentSpeed = 0;
            _transform = transform;
        }

        public void Accelerate()
        {
            _movementDirection = Vector2.up;

            if (_currentSpeed < _maxSpeed) _currentSpeed += _accelerationValue;
            else if (_currentSpeed > _maxSpeed) _currentSpeed = _maxSpeed;

            CalculateDirection();

            MovementUpdated.Invoke(_currentSpeed, _movementDirection);
        }

        public void Inert()
        {
            if (_currentSpeed > 0) _currentSpeed -= _inertionValue;
            else if (_currentSpeed < 0) _currentSpeed = 0;

            MovementUpdated.Invoke(_currentSpeed, _movementDirection);
        }

        private void CalculateDirection()
        {
            //TODO: переработать расчёт направления
            _movementDirection = Vector2.Lerp(_movementDirection, _transform.up, Time.deltaTime);
        }
    }
}