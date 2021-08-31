
using UnityEngine;

namespace Movement
{
    public class InertionMovementView : MonoBehaviour
    {
        [SerializeField] protected float _maxMovementSpeed;
        [SerializeField] private float _maxRotationSpeed;

        private float _currentMovementSpeed;
        private Vector2 _movementDirection;
        private float _rotationDirection;

        public float CurrentMovementSpeed { set { _currentMovementSpeed = value; } }
        public Vector2 MovementDirection { set { _movementDirection = value; } }
        public float RotationDirection { set { _rotationDirection = value; } }

        public float MaxMovementSpeed => _maxMovementSpeed;

        private void Update()
        {
            transform.Translate(_movementDirection * _currentMovementSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 45) * _rotationDirection * _maxRotationSpeed * Time.deltaTime);
        }

        public void UpdateMovement(float currentMovementSpeed, Vector2 movementDirection)
        {
            _currentMovementSpeed = currentMovementSpeed;
            _movementDirection = movementDirection;
        }
    }
}