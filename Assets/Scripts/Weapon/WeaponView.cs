using UnityEngine;

namespace Weapons
{
    /// <summary>
    /// Представление оружия
    /// </summary>
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] protected GameObject _shootingPosition;

        private int _currentCharges;
        private float _chargeCooldown;

        public int CurrentCharges => _currentCharges;
        public float ChargeCooldown => _chargeCooldown;

        public void Shoot(GameObject _projectile)
        {
            Instantiate(_projectile, _shootingPosition.transform.position, transform.rotation);
        }

        public void UpdateCharges(int currentCharges, float chargeCooldown)
        {
            _currentCharges = currentCharges;
            _chargeCooldown = chargeCooldown;
        }
    }
}