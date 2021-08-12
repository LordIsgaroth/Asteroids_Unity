using UnityEngine;

public class WeaponWithCharges : Weapon
{
    [SerializeField] private int _maximumCharges;
    [SerializeField] private float _chargeResetCooldown;

    private ChargesController _chargesController;

    private new void Start()
    {
        base.Start();
        _chargesController = new ChargesController(_maximumCharges, _chargeResetCooldown);
    }

    private new void Update()
    {
        base.Update();
        Debug.Log($"Charges: {_chargesController.CurrentCharges} Cooldown: {_chargesController.CurrentResetCooldown}");
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