using System.Collections;
using UnityEngine;
using Movement;
using BaseObjects;
using System.Collections.Generic;

namespace Spawning
{
    /// <summary>
    /// Управление генерацией объектов
    /// </summary>
    [RequireComponent(typeof(GameController))]
    public class SpawningController : MonoBehaviour
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private GameController _gameController;
        [SerializeField] private MovementRestriction _borders;
        private SpawninigByScreenSides _spawningModel;        
        private Queue<SpawnParameters> _spawningQueue = new Queue<SpawnParameters>();

        void Start()
        {
            _spawningModel = new SpawninigByScreenSides(_spawnCooldown, _borders);
            _spawningModel.OnSpawnEvent += AddToSpawning;
            _spawningModel.StartSpawning();

            StartCoroutine(Spawning());            
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
            EnemyCreator.Create(spawnParameters, _gameController.PlayerPositionChanged);

            //SpawnParameters spawnParameters = new SpawnParameters(); //GetSpawnParameters();
            //spawnParameters.Position = new Vector2(0, 0);
            //spawnParameters.RotationAngle = 45;

            //GameObject prefab = (GameObject)Resources.Load("Prefabs/Asteroid", typeof(GameObject));

            //try
            //{
            //    Instantiate(PrefabsManager.GetPrefabByName(spawnParameters.PrefabType), spawnParameters.Position, Quaternion.identity);
            //}
            //catch(System.Exception e)
            //{
            //    Debug.Log(e.Message);
            //}
            

            //EnemyCreator.CreateByType(prefab, spawnParameters);
            //EnemyCreator.CreateByType(_enemyTypeSelector.SelectType(), spawnParameters);

            //_cooldownController.StartCooldown();

            //SpawnParameters spawnParameters = _spawningModel.GetSpawnParameters();

            //EnemyCreator.CreateByType(type, spawnParameters);



            //GameObject generatedObject = Instantiate(PrefabsManager.GetPrefabByName(type), spawnParameters.Position, Quaternion.identity);
            //generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(_gameController.Collision);

            //if (type == "UFO")
            //{
            //    SpaceShip movementController = generatedObject.GetComponent<SpaceShip>();
            //    if (movementController == null) throw new System.Exception("UFO does not contain SpaceShip!");
            //    _gameController.PlayerPositionChanged.AddListener(movementController.SetTargetPosition);
            //}
            //else
            //{
            //    generatedObject.transform.Rotate(0, 0, spawnParameters.RotationAngle);
            //}
        }

        private void AddToSpawning(SpawnParameters spawnParameters)
        {
            _spawningQueue.Enqueue(spawnParameters);
        }

    }
}