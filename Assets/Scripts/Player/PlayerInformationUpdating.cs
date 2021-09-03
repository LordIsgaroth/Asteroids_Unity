using UnityEngine;
using Movement;
using Weapons;
using BaseObjects;

/// <summary>
/// Обновление информации об игроке
/// </summary>
public class PlayerInformationUpdating : MonoBehaviour
{
    [SerializeField] private MovementView _movementView;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private PositionView _positionView;
    
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
        _playerInformation.Position = _positionView.CurrentPositon;
    }

    private void SetPlayerAngle()
    {
        _playerInformation.Angle = _positionView.CurrentAngle;
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
