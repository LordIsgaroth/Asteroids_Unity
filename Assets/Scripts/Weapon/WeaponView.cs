using UnityEngine;

namespace Weapons
{
    /// <summary>
    /// Представление оружия
    /// </summary>
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] protected GameObject _shootingPosition;

        public void Shoot(GameObject _projectile)
        {
            Instantiate(_projectile, _shootingPosition.transform.position, _shootingPosition.transform.rotation);
        }        
    }
}