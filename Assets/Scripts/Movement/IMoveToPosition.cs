using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Интерфейс движения к заданной позиции
    /// </summary>
    public interface IMoveToPosition
    {
        public void SetTargetPosition(Vector2 position);
    }
}
