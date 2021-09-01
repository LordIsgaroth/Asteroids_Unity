using UnityEngine;
using UnityEngine.Events;
using BaseObjects;

namespace Weapons
{
    public class WeaponModel
    {
        protected GameObject _projectile;
        protected ICooldown _cooldownController;

        public float CurrentCooldown { get => _cooldownController.GetCurrentCooldown(); }

        public UnityEvent<GameObject> OnShootEvent = new UnityEvent<GameObject>();

        public WeaponModel(float cooldown, GameObject projectile)
        {
            float cooldownStep = 0.001f;

            _cooldownController = new CooldownByStep(cooldown, cooldownStep);
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