using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Представление движения в указанном направлении с возможностью поворота
    /// </summary>
    public class MovementByDirectionWithRotationView : MovementByDirectionView
    {                
        private float _rotationSpeed;
        private float _rotationDirection;
        
        public float RotationSpeed { set { _rotationSpeed = value; } }
        public float RotationDirection { set { _rotationDirection = value; } }        

        private void Update()
        {           
            transform.Translate(_movementDirection * _movementSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 45) * _rotationDirection * _rotationSpeed * Time.deltaTime);
        }

        public void UpdateMovement(float currentMovementSpeed, Vector2 movementDirection)
        {
            _movementSpeed = currentMovementSpeed;
            _movementDirection = movementDirection;
        }
    }
}