using UnityEngine;

namespace Spawning
{
    public static class EnemyCreator
    {
        public static GameObject Create(SpawnParameters spawnParameters)
        {
            GameObject prefab = PrefabsManager.GetPrefabByName(spawnParameters.PrefabType);

            GameObject generatedObject = GameObject.Instantiate(prefab, spawnParameters.Position, Quaternion.identity);
            generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(CollisionManager.GetInstanse().Collision);

            if (spawnParameters.PrefabType == "UFO")
            {
                SpaceShip movementController = generatedObject.GetComponent<SpaceShip>();
                if (movementController == null) throw new System.Exception("UFO does not contain SpaceShip!");
                //_gameController.PlayerPositionChanged.AddListener(movementController.SetTargetPosition);
            }
            else
            {
                generatedObject.transform.Rotate(0, 0, spawnParameters.RotationAngle);
            }

            return generatedObject;
        }
    }
}
