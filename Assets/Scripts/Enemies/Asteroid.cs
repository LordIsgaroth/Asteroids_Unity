using UnityEngine;
using Movement;

public class Asteroid : Enemy
{
    private IMoveToPsition _movementController;

    void Start()
    {
        _movementController = gameObject.GetComponent<IMoveToPsition>();
        if (_movementController == null) throw new System.Exception("Movement script is missing!");

        SetOppositeDestination();
    }

    /// <summary>
    /// Астероид всегда летит в сторону, противоположную начальной позиции
    /// </summary>
    private void SetOppositeDestination()
    {
        Vector2 oppositeDestination = new Vector2();

        float currentX = transform.position.x;
        float currentY = transform.position.y;

        if (currentX < 0) oppositeDestination.x = -currentX + 10;
        else oppositeDestination.x = -currentX - 10;

        if (currentY < 0) oppositeDestination.y = -currentY + 10;
        else oppositeDestination.y = -currentY - 10;

        _movementController.SetTargetPosition(oppositeDestination);
    }
}
