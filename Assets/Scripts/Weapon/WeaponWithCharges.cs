using UnityEngine;

public class WeaponWithCharges : Weapon
{
    private ChargesController _chargesController;

    [SerializeField] private int _maximumCharges;
    [SerializeField] private float _chargeResetCooldown;

    public int Charges { get => _chargesController.CurrentCharges; }
    public float Cooldown { get => _chargesController.CurrentResetCooldown; }

    private new void Start()
    {
        base.Start();
        _chargesController = new ChargesController(_maximumCharges, _chargeResetCooldown);
    }

    private new void Update()
    {
        base.Update();       
        _chargesController.ReduceCooldown(Time.deltaTime);
    }

    public override void Shoot()
    {
        if(_currentCooldown == 0 &&  _chargesController.CurrentCharges > 0)
        {
            base.Shoot();
            _chargesController.UseCharge();
        } 
    }
}