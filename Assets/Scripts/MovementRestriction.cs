using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ќграничивает выход игрока за пределы игровой зоны
/// </summary>
public class MovementRestriction : MonoBehaviour
{
    [SerializeField] private Player player;

    void OnTriggerExit2D(Collider2D other)
    {
        // огда игрок выходит за пределы этого объекта - он возвращаетс€ обратно с противоположной его стороны стороны
        player.transform.position = new Vector3(-player.transform.position.x, -player.transform.position.y);
    }
}
