using UnityEngine;
using Movement;
using Weapons;

public class PlayerInformationUpdating : MonoBehaviour
{
    [SerializeField] private InertionMovement _movementController;
    [SerializeField] private WeaponWithCharges _weaponWithCharges;

    private Vector2 _currentPosition;
    private PlayerInformation _playerInformation;

    public PlayerInformation PlayerInformation { get => _playerInformation; }

    private void Start()
    {
        _playerInformation = new PlayerInformation();
    }

    private void Update()
    {
        UpdatePlayerInformation();
    }

    private void UpdatePlayerInformation()
    {
        SetPlayerPosition();
        SetPlayerAngle();
        SetPlayerSpeed();
        SetWeaponCharges();
        SetWeaponCooldown();
    }

    private void SetPlayerPosition()
    {
        _currentPosition.x = transform.position.x;
        _currentPosition.y = transform.position.y;
        _playerInformation.Position = _currentPosition;
    }

    private void SetPlayerAngle()
    {
        _playerInformation.Angle = transform.rotation.eulerAngles.z;
    }

    private void SetPlayerSpeed()
    {
        _playerInformation.Speed = _movementController.CurrentSpeed;
    }

    private void SetWeaponCharges()
    {
        _playerInformation.WeaponCharges = _weaponWithCharges.Charges;
    }

    private void SetWeaponCooldown()
    {
        _playerInformation.ChargeCooldown = _weaponWithCharges.Cooldown;
    }
}
