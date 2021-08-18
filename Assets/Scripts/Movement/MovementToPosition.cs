using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Движение к заданной позиции
    /// </summary>
    public class MovementToPosition : Movement, IMoveToPosition
    {
        protected Vector2 _movementDestination = new Vector2();

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, _movementDestination, _movementSpeed * Time.deltaTime);
        }

        public void SetTargetPosition(Vector2 position)
        {
            _movementDestination = position;
        }
    }
}