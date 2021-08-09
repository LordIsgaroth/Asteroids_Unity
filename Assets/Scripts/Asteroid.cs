using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
    void Start()
    {
        SetMovementDestination(transform.position);
    }

    /// <summary>
    /// Астероид всегда летит в сторону, противоположную начальной позиции
    /// </summary>
    private void SetMovementDestination(Vector3 position)
    {
        if (position.x < 0) _movementDestination.x = -position.x + 10;
        else _movementDestination.x = -position.x - 10;

        if (position.y < 0) _movementDestination.y = -position.y + 10;
        else _movementDestination.y = -position.y - 10;
    }
}
