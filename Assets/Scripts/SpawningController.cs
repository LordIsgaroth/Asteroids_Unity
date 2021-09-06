using Movement;
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

        private SpawninigByScreenSides _spawningModel;        
        private Queue<SpawnParameters> _spawningQueue = new Queue<SpawnParameters>();

        private UnityEvent<Vector2> _playerPositionChangedEvent = new UnityEvent<Vector2>();

        void Start()
        {
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
            EnemyCreator.Create(spawnParameters, _playerPositionChangedEvent);
        }

        private void AddToSpawning(SpawnParameters spawnParameters)
        {
            _spawningQueue.Enqueue(spawnParameters);
        }
    }
}