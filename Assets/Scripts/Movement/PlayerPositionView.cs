using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Отображение местоположения игрока
    /// </summary>
    public class PlayerPositionView : MonoBehaviour
    {
        [SerializeField] GameObject _childObject;

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

        public float CurrentAngle => _childObject.transform.rotation.eulerAngles.z;
    }
}