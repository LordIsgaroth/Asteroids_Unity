using UnityEngine;

namespace Movement
{
    /// <summary>
    /// ѕредставление движени€ в заданном направлении
    /// </summary>
    public class MovementByDirectionView : MovementView
    {
        protected Vector2 _movementDirection = Vector2.up;
        public Vector2 MovementDirection { set { _movementDirection = value; } }

        void Update()
        {
            transform.Translate(_movementDirection * _movementSpeed * Time.deltaTime);
        }
    }
}