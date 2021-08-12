using UnityEngine;
using Movement;

public class PlayerInformation : MonoBehaviour
{
    [SerializeField] private InertionMovement _movementController;
    [SerializeField] private WeaponWithCharges _weapon;

    private Vector2 _position;
    private float _angle;
    private float _speed;
    private int _weaponCharges;
    private float _weaponCooldown;

    public Vector2 Position { get => _position; }
    public float Angle { get => _angle; }
    public float Speed { get => _speed; }    
    public int WeaponCharges { get => _weaponCharges; }
    public float WeaponCooldown { get => _weaponCooldown; }

    private void Start()
    {
        _position = new Vector2();
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
        _position.x = transform.position.x;
        _position.y = transform.position.y;
    }

    private void SetPlayerAngle()
    {
        _angle = transform.rotation.eulerAngles.z;
    }

    private void SetPlayerSpeed()
    {
        _speed = _movementController.CurrentSpeed;
    }

    private void SetWeaponCharges()
    {
        _weaponCharges = _weapon.Charges;
    }

    private void SetWeaponCooldown()
    {
        _weaponCooldown = _weapon.Cooldown;
    }
}
