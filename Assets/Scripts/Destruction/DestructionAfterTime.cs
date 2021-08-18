using UnityEngine;

namespace Destruction
{
    /// <summary>
    /// ”ничтожение спуст€ заданное врем€
    /// </summary>
    public class DestructionAfterTime : MonoBehaviour
    {
        [SerializeField] private float _lifetime;

        void Update()
        {
            ReduceLifetime();
            DestroyWhenTimeIsOver();
        }

        private void ReduceLifetime()
        {
            _lifetime -= Time.deltaTime;
        }

        private void DestroyWhenTimeIsOver()
        {
            if (_lifetime <= 0) Destroy(gameObject);
        }
    }
}