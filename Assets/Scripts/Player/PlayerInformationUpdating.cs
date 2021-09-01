using UnityEngine;
using Movement;
using Weapons;

/// <summary>
/// Обновление информации об игроке
/// </summary>
public class PlayerInformationUpdating : MonoBehaviour
{
    [SerializeField] private MovementView _movementView;
    [SerializeField] private WeaponView _weaponView;

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
        _playerInformation.Speed = _movementView.MovementSpeed;
    }

    private void SetWeaponCharges()
    {
        _playerInformation.WeaponCharges = _weaponView.CurrentCharges;
    }

    private void SetWeaponCooldown()
    {
        _playerInformation.ChargeCooldown = _weaponView.ChargeCooldown;
    }
}
