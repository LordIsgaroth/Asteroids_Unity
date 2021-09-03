using Movement;
using UnityEngine;

[RequireComponent(typeof(MovementToPositionView))]
public class SpaceShip : SpaceObject
{
    new protected void Awake()
    {
        _movementView = GetComponent<MovementToPositionView>();
        _movementView.MovementSpeed = _movementSpeed;        
    }

    public void SetTargetPosition(Vector2 position)
    {
        (_movementView as MovementToPositionView).MovementDestination = position;
    }
}
