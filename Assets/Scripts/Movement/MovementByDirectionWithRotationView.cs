using UnityEngine;

namespace Movement
{
    /// <summary>
    /// ������������� �������� � ��������� ����������� � ������������ ��������
    /// </summary>
    public class MovementByDirectionWithRotationView : MovementByDirectionView
    {
        [SerializeField] GameObject _childObject;

        private float _rotationSpeed;
        private float _rotationDirection;
        
        public float RotationSpeed { set { _rotationSpeed = value; } }
        public float RotationDirection { set { _rotationDirection = value; } }

        private void Update()
        {
            transform.Translate(_movementDirection * _movementSpeed * Time.deltaTime);
            _childObject.transform.Rotate(new Vector3(0, 0, 45) * _rotationDirection * _rotationSpeed * Time.deltaTime);
        }

        public void UpdateMovement(float currentMovementSpeed, Vector2 movementDirection)
        {
            _movementSpeed = currentMovementSpeed;
            _movementDirection = movementDirection;
        }
    }
}