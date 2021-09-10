using Movement;
using UnityEngine;

namespace Projectiles
{
    /// <summary>
    /// Движущийся снаряд
    /// </summary>
    [RequireComponent(typeof(MovementView))]
    public class MovingProjectile : MonoBehaviour
    {
        [SerializeField] protected float _movementSpeed;

        private MovementView _movementView;

        public void Awake()
        {
            _movementView = GetComponent<MovementView>();
            _movementView.MovementSpeed = _movementSpeed;
        }
    }
}