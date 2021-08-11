using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Shooting _shootingController;
    [SerializeField] private InertionMovement _movementController;

    //TODO: переработать систему стрельбы
    private GameObject _mainProjectile;

    void Start()
    {
        _mainProjectile = Shooting.GetProjectileByName("PlasmaBolt");
    }

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
        _shootingController.Shoot(_mainProjectile);
    }
}
