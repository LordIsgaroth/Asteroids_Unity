using Movement;
using Enemies;
using BaseObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Spawning
{
    /// <summary>
    /// Управление генерацией объектов
    /// </summary>    
    public class SpawningController : MonoBehaviour
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private PlayerPositionView _playerPosition;
        [SerializeField] private MovementRestriction _borders;

        private ISpawning _spawningModel;
        private Queue<SpawnParameters> _spawningQueue = new Queue<SpawnParameters>();

        private UnityEvent<Vector2> _playerPositionChangedEvent = new UnityEvent<Vector2>();

        void Start()
        {
            EnemyCollisionManager collisionManager = EnemyCollisionManager.GetInstanse();
            collisionManager.AsteroidShattersEvent.AddListener(SpawnShatters);

            _spawningModel = new SpawninigByScreenSides(_spawnCooldown, _borders);
            _spawningModel.OnSpawnEvent += AddToSpawning;
            _spawningModel.StartSpawning();

            StartCoroutine(Spawning());            
        }

        void Update()
        {
            _playerPositionChangedEvent.Invoke(_playerPosition.CurrentPositon);            
        }

        private IEnumerator Spawning()
        {            
            while (true)
            {
                if(_spawningQueue.Count > 0)
                {
                    SpawnParameters spawnParameters = _spawningQueue.Dequeue();
                    SpawnObject(spawnParameters);
                }

                yield return new WaitForSeconds(0.01f);
            }
        }

        private void SpawnObject(SpawnParameters spawnParameters)
        {
            EnemyCreator enemyCreator;

            if (spawnParameters.PrefabType == "Asteroid")
            {
                enemyCreator = new AsteroidCreator(spawnParameters.Position, spawnParameters.RotationAngle);
                enemyCreator.Create();
            }
            else if (spawnParameters.PrefabType == "UFO")
            {
                enemyCreator = new UFOCreator(spawnParameters.Position, _playerPositionChangedEvent);
                enemyCreator.Create();
            }                            
        }

        private void AddToSpawning(SpawnParameters spawnParameters)
        {
            _spawningQueue.Enqueue(spawnParameters);
        }

        private void SpawnShatters(Vector3 position, float angle)
        {
            float shardRotationAngle = 50f;

            ShardCreator firstCreator = new ShardCreator(position, angle + shardRotationAngle);
            firstCreator.Create();

            ShardCreator secondCreator = new ShardCreator(position, angle - shardRotationAngle);
            secondCreator.Create();
        }
    }
}