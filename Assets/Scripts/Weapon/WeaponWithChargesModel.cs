using UnityEngine;

namespace Weapons
{
    public class WeaponWithChargesModel : WeaponModel
    {
        private ChargesController _chargesController;

        public int Charges { get => _chargesController.CurrentCharges; }
        public float ChargeCooldown { get => _chargesController.CurrentResetCooldown; }

        public WeaponWithChargesModel(float cooldown, GameObject projectile, int maximumCharges, float chargeResetCooldown)
            :base(cooldown, projectile)
        {
            _chargesController = new ChargesController(maximumCharges, chargeResetCooldown);
        }

        public override void Shoot()
        {
            if (CurrentCooldown == 0 && _chargesController.CurrentCharges > 0)
            {
                base.Shoot();
                _chargesController.UseCharge();
            }
        }
    }
}
