using UnityEngine;
using BaseObjects;
using UnityEngine.Events;

namespace Enemies
{
    /// <summary>
    /// Создание НЛО
    /// </summary>
    public class UFOCreator : EnemyCreator
    {
        private UnityEvent<Vector2> _playerPositionChanged;

        public UFOCreator(Vector3 spawnPosition, UnityEvent<Vector2> playerPositionChanged)
            : base(spawnPosition)
        {
            _prefabName = "UFO";
            _playerPositionChanged = playerPositionChanged;
        }

        public override GameObject Create()
        {
            GameObject prefab = PrefabsManager.GetPrefabByName(_prefabName);

            GameObject generatedObject = GameObject.Instantiate(prefab, _spawnPosition, Quaternion.identity);
            generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(EnemyCollisionManager.GetInstanse().Collision);

            SpaceShip movementController = generatedObject.GetComponent<SpaceShip>();
            if (movementController == null) throw new System.Exception("UFO does not contain SpaceShip!");
            if (_playerPositionChanged == null) throw new System.Exception("Player position changed event is required for UFO!");
            _playerPositionChanged.AddListener(movementController.SetTargetPosition);

            return generatedObject;
        }
    }
}