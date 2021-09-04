using UnityEngine;
using UnityEngine.Events;
using BaseObjects;

namespace Weapons
{
    /// <summary>
    /// Модель оружия
    /// </summary>
    public class WeaponModel
    {
        protected GameObject _projectile;
        protected ICooldown _cooldownController;

        public float CurrentCooldown  => _cooldownController.GetCurrentCooldown();

        public UnityEvent<GameObject> OnShootEvent = new UnityEvent<GameObject>();

        public WeaponModel(float cooldown, GameObject projectile)
        {
            double cooldownInMilliseconds = cooldown * 1000;
            double cooldownStepInMilliseconds = 10;

            _cooldownController = new CooldownByStep(cooldownInMilliseconds, cooldownStepInMilliseconds);
            _projectile = projectile;
        }

        public virtual void Shoot()
        {
            if (CurrentCooldown == 0)
            {
                _cooldownController.StartCooldown();
                OnShootEvent.Invoke(_projectile);
            }
        }
    }
}