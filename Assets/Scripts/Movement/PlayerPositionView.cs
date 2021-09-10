using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Отображение местоположения игрока
    /// </summary>
    public class PlayerPositionView : MonoBehaviour
    {
        [SerializeField] GameObject _childObject;

        public Vector2 CurrentPositon => transform.position;
        public float CurrentAngle => _childObject.transform.rotation.eulerAngles.z;
    }
}