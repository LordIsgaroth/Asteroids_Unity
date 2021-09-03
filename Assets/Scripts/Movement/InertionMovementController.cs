using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    // TODO: избавиться от наследования от MonoBeh

    /// <summary>
    /// Контроллер движения с инерцией
    /// </summary>
    public class InertionMovementController : MonoBehaviour
    {
        [SerializeField] private float _inertionValue;
        [SerializeField] private float _accelerationValue;
        [SerializeField] private float _maxMovementSpeed;
        [SerializeField] private float _maxRotationSpeed;

        private bool _accelerated;

        public MovementByDirectionWithRotationView View { get; private set; }
        public InertionMovementModel Model { get; private set; }

        private void Awake()
        {
            View = GetComponent<MovementByDirectionWithRotationView>();
            View.RotationSpeed = _maxRotationSpeed;

            Model = new InertionMovementModel(_accelerationValue, _inertionValue, _maxMovementSpeed, View.transform);
            Model.MovementUpdated.AddListener(View.UpdateMovement);
        }

        private void FixedUpdate()
        {
            if (_accelerated) Model.Accelerate();
            Model.Inert();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _accelerated = !context.canceled;
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            View.RotationDirection = -context.ReadValue<Vector2>().x;
        }
    }
}