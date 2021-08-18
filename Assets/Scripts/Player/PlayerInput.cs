using UnityEngine;
using UnityEngine.InputSystem;
using Movement;
using Weapons;

/// <summary>
/// Обработка пользовательского ввода
/// </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Weapon _mainWeapon;
    [SerializeField] private WeaponWithCharges _laserGun;
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

    public void OnFireCharged(InputAction.CallbackContext context)
    {
        _laserGun.Shoot();
    }
}
