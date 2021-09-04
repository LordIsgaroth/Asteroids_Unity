using UnityEngine;

namespace BaseObjects
{
    /// <summary>
    /// Отображение местоположения объекта
    /// </summary>
    public class PositionView : MonoBehaviour
    {
        private Vector2 _currentPosition = new Vector2();

        public Vector2 CurrentPositon
        {
            get
            {
                _currentPosition.x = transform.position.x;
                _currentPosition.y = transform.position.y;
                return _currentPosition;
            }
        }

        public float CurrentAngle => transform.rotation.eulerAngles.z;
    }
}