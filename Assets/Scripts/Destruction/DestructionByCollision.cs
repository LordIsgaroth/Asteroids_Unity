using UnityEngine;

namespace Destruction
{
    public class DestructionByCollision : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}