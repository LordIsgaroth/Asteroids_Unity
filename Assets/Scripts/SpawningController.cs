using System.Collections;
using UnityEngine;
using Movement;
using BaseObjects;

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
        private ISpawning _spawning;

        void Start()
        {
            _spawning = new SpawninigByScreenSides(_borders);
            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            yield return new WaitForSeconds(_spawnCooldown);

            while (true)
            {
                SpawnObject(ChooseEnemyType());

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private string ChooseEnemyType()
        {
            int generationValue = Random.Range(1, 101);

            if (generationValue >= 85) return "UFO";
            else return "Asteroid";
        }

        private void SpawnObject(string type)
        {
            SpawnParameters spawnParameters = _spawning.GetSpawnParameters();
            GameObject generatedObject = Instantiate(PrefabsManager.GetPrefabByName(type), spawnParameters.Position, Quaternion.identity);
            generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(_gameController.Collision);

            if (type == "UFO")
            {
                SpaceShip movementController = generatedObject.GetComponent<SpaceShip>();
                if (movementController == null) throw new System.Exception("UFO does not contain SpaceShip!");
                _gameController.PlayerPositionChanged.AddListener(movementController.SetTargetPosition);
            }
            else
            {
                generatedObject.transform.Rotate(0, 0, spawnParameters.RotationAngle);
            }
        }
    }
}