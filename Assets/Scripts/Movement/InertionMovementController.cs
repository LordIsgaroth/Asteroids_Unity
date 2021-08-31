using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    // TODO: избавиться от наследования от MonoBeh
    public class InertionMovementController : MonoBehaviour
    {
        [SerializeField] private float _inertionValue;
        [SerializeField] private float _accelerationValue;

        private bool _accelerated;

        public InertionMovementView View { get; private set; }
        public InertionMovementModel Model { get; private set; }

        private void Awake()
        {
            View = GetComponent<InertionMovementView>();
            Model = new InertionMovementModel(_accelerationValue, _inertionValue, View.MaxMovementSpeed, View.transform);
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