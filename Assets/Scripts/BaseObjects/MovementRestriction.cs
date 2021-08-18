using UnityEngine;

namespace BaseObjects
{
    /// <summary>
    /// Ограничение перемещения объектов
    /// </summary>
    public class MovementRestriction : MonoBehaviour
    {
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player") RevertPosition(other);
            else Destroy(other.gameObject);
        }

        /// <summary>
        /// Возвращает объект с обратной стороны игровой зоны
        /// </summary>    
        private void RevertPosition(Collider2D other)
        {
            other.transform.position = new Vector3(-other.transform.position.x, -other.transform.position.y);
        }
    }
}
