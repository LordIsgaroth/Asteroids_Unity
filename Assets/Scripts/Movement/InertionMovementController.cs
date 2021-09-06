using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{   
    /// <summary>
    /// Контроллер движения с инерцией
    /// </summary>
    public class InertionMovementController : MonoBehaviour
    {
        [SerializeField] GameObject _childObject;
        [SerializeField] private float _inertionValue;
        [SerializeField] private float _accelerationValue;
        [SerializeField] private float _maxMovementSpeed;
        [SerializeField] private float _maxRotationSpeed;

        private bool _accelerated;

        private MovementByDirectionWithRotationView _view;
        private InertionMovement _model;        

        private void Awake()
        {
            _view = GetComponent<MovementByDirectionWithRotationView>();
            _view.RotationSpeed = _maxRotationSpeed;

            _model = new InertionMovement(_accelerationValue, _inertionValue, _maxMovementSpeed, _childObject.transform);
            _model.MovementUpdated.AddListener(_view.UpdateMovement);
        }

        private void FixedUpdate()
        {
            if (_accelerated) _model.Accelerate();
            _model.Inert();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _accelerated = !context.canceled;
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            _view.RotationDirection = -context.ReadValue<Vector2>().x;
        }
    }
}