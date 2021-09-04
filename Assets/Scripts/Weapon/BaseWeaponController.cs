using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons
{
    /// <summary>
    /// Базовый контроллер оружия
    /// </summary>
    public abstract class BaseWeaponController : MonoBehaviour
    {
        [SerializeField] protected GameObject _projectile;
        [SerializeField] protected float _shootingCooldown;

        protected WeaponView _view;
        protected WeaponModel _model;

        public void OnFire(InputAction.CallbackContext context)
        {
            _model.Shoot();
        }
    }
}    
