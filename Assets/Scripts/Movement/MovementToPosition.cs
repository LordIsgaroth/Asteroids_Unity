using UnityEngine;

namespace Movement
{
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