using UnityEngine;

namespace Movement
{
    /// <summary>
    /// ѕредставление движени€ к заданной позиции
    /// </summary>
    public class MovementToPositionView : MovementView
    {
        private Vector2 _movementDestination = new Vector2();
        public Vector2 MovementDestination { set { _movementDestination = value; } }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, _movementDestination, _movementSpeed * Time.deltaTime);
        }        
    }
}