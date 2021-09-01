
namespace Weapons
{
    public class MainWeaponController : BaseWeaponController
    {
        private void Awake()
        {
            _view = GetComponent<WeaponView>();
            _model = new WeaponModel(_shootingCooldown, _projectile);
            _model.OnShootEvent.AddListener(_view.Shoot);
        } 
    }
}
