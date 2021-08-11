using UnityEngine;
using UnityEngine.InputSystem;
using Movement;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Weapon _mainWeapon;
    [SerializeField] private InertionMovement _movementController;

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementController.Accelerated = !context.canceled;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _movementController.RotateDirection = -context.ReadValue<Vector2>().x;
    }

    public void OnFireMain(InputAction.CallbackContext context)
    {
        _mainWeapon.Shoot();
    }
}
