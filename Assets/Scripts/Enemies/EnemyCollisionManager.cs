using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    /// <summary>
    /// Управление столкновениями объектов
    /// </summary>
    public class EnemyCollisionManager
    {
        private static EnemyCollisionManager _instance;

        public UnityEvent PlayerCollidedEvent = new UnityEvent();
        public UnityEvent<int> SpaceObjectDestroyedEvent = new UnityEvent<int>();
        public UnityEvent<Vector3, float> AsteroidShattersEvent = new UnityEvent<Vector3, float>();

        private EnemyCollisionManager() { }

        public static EnemyCollisionManager GetInstanse()
        {
            if (_instance == null) _instance = new EnemyCollisionManager();
            return _instance;
        }

        public void Collision(SpaceObject spaceObject, Collider2D other)
        {
            if (other.tag == "Player")
            {
                GameObject.Destroy(other.gameObject);
                PlayerCollidedEvent.Invoke();
            }
            else if (other.tag == "SimpleProjectile" && spaceObject.tag == "Shatters")
            {
                GameObject.Destroy(spaceObject.gameObject);
                SpaceObjectDestroyedEvent.Invoke(spaceObject.Score);
                GenerateShards(spaceObject);
            }
            else if ((other.tag == "SimpleProjectile" && !(spaceObject.tag == "Shatters")) || other.tag == "AdvancedProjectile")
            {
                GameObject.Destroy(spaceObject.gameObject);
                SpaceObjectDestroyedEvent.Invoke(spaceObject.Score);
            }
        }

        private void GenerateShards(SpaceObject enemy)
        {
            Vector3 enemyPosition = enemy.transform.position;
            float enemyAngle = enemy.transform.rotation.eulerAngles.z;

            AsteroidShattersEvent.Invoke(enemyPosition, enemyAngle);            
        }
    }
}