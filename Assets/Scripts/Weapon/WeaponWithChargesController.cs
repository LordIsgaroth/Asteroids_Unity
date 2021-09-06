using UnityEngine;

namespace Weapons
{
    /// <summary>
    /// Контроллер оружия с зарядами
    /// </summary>
    public class WeaponWithChargesController : BaseWeaponController
    {
        [SerializeField] private int _maximumCharges;
        [SerializeField] private float _chargeResetCooldown;

        private void Awake()
        {
            _view = GetComponent<WeaponView>();
            _model = new WeaponWithCharges(_shootingCooldown, _projectile, _maximumCharges, _chargeResetCooldown);
            _model.OnShootEvent.AddListener(_view.Shoot);
        }

        private void Update()
        {
            _view.UpdateCharges((_model as WeaponWithCharges).Charges, (_model as WeaponWithCharges).ChargeCooldown);
        }
    }
}