using BaseObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Spawning
{
    public static class EnemyCreator
    {
        public static GameObject Create(SpawnParameters spawnParameters, UnityEvent<Vector2> playerPositionChanged = null)
        {
            GameObject prefab = PrefabsManager.GetPrefabByName(spawnParameters.PrefabType);

            GameObject generatedObject = GameObject.Instantiate(prefab, spawnParameters.Position, Quaternion.identity);
            generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(CollisionManager.GetInstanse().Collision);

            if (spawnParameters.PrefabType == "UFO")
            {
                SpaceShip movementController = generatedObject.GetComponent<SpaceShip>();
                if (movementController == null) throw new System.Exception("UFO does not contain SpaceShip!");
                if (playerPositionChanged == null) throw new System.Exception("Player position changed event is required for UFO!");
                playerPositionChanged.AddListener(movementController.SetTargetPosition);
            }
            else
            {
                generatedObject.transform.Rotate(0, 0, spawnParameters.RotationAngle);
            }

            return generatedObject;
        }
    }
}
