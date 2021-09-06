
namespace Weapons
{
    /// <summary>
    /// Контроллер основного оружия
    /// </summary>
    public class MainWeaponController : BaseWeaponController
    {
        private void Awake()
        {
            _view = GetComponent<WeaponView>();
            _model = new Weapon(_shootingCooldown, _projectile);
            _model.OnShootEvent.AddListener(_view.Shoot);
        } 
    }
}
