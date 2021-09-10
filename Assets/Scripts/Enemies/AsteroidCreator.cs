using UnityEngine;
using BaseObjects;

namespace Enemies
{
    /// <summary>
    /// Создание астероида
    /// </summary>
    public class AsteroidCreator : EnemyCreator
    {
        private float _rotationAngle;

        public AsteroidCreator(Vector3 spawnPosition, float rotationAngle)
            : base(spawnPosition)
        {
            _prefabName = "Asteroid";
            _rotationAngle = rotationAngle;
        }

        public override GameObject Create()
        {
            GameObject prefab = PrefabsManager.GetPrefabByName(_prefabName);

            GameObject generatedObject = GameObject.Instantiate(prefab, _spawnPosition, Quaternion.identity);
            generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(EnemyCollisionManager.GetInstanse().Collision);
            generatedObject.transform.Rotate(0, 0, _rotationAngle);

            return generatedObject;
        }
    }
}