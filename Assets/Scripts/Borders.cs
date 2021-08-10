using UnityEngine;

/// <summary>
/// Границы игровой зоны
/// </summary>
public class Borders : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") RevertPosition(other);
        else Destroy(other.gameObject);
    }

    /// <summary>
    /// Когда игрок выходит за пределы игровой зоны - он возвращается обратно с противоположной стороны
    /// </summary>    
    private void RevertPosition(Collider2D other)
    {
        other.transform.position = new Vector3(-other.transform.position.x, -other.transform.position.y);
    }
}
