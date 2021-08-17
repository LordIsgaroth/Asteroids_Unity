using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Movement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInformationUpdating _playerInformationUpdating;
    [SerializeField] private DisplayToInterface _interfaceDisplayer;
    [SerializeField] private GameObject _borders;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private GameOver _gameOverManager;

    private int _score = 0;

    public UnityEvent<Vector2> PlayerPositionChanged = new UnityEvent<Vector2>();
    public UnityEvent<int> ScoreChanged = new UnityEvent<int>();

    void Start()
    {        
        StartCoroutine(Spawning());
        ScoreChanged.AddListener(_interfaceDisplayer.SetScore);
    }
   
    void Update()
    {
        PlayerPositionChanged.Invoke(_playerInformationUpdating.PlayerInformation.Position);
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(_spawnCooldown);

        while(true)
        {
            SpawnObject(ChooseEnemyType());

            yield return new WaitForSeconds(_spawnCooldown);
        }        
    }
    private string ChooseEnemyType()
    {
        int generationValue = Random.Range(1, 101);

        if (generationValue >= 75) return "UFO";
        else return "Asteroid";        
    }

    private void SpawnObject(string type)
    {
        SpawnParameters spawnParameters = EnemyGeneration.GetSpawnParameters(_borders);
        GameObject generatedObject = Instantiate(EnemyGeneration.GetPrefabByName(type), spawnParameters.Position, Quaternion.identity);        
        generatedObject.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);

        if(type == "UFO")
        {
            IMoveToPosition movementController = generatedObject.GetComponent<IMoveToPosition>();
            if (movementController == null) throw new System.Exception("UFO does not contain IMoveToPosition!");
            PlayerPositionChanged.AddListener(movementController.SetTargetPosition);
        }
        else
        {
            generatedObject.transform.Rotate(0, 0, spawnParameters.RotationAngle);
        }
    }

    private void Collision(SpaceObject spaceObject, Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
            GameOver();
        }
        else if(other.tag == "SimpleProjectile" && spaceObject.tag == "Shatters")
        {
            Destroy(spaceObject.gameObject);
            GenerateShards(spaceObject);
            AddScore(spaceObject);
        }
        else if((other.tag == "SimpleProjectile" && !(spaceObject.tag == "Shatters")) || other.tag == "AdvancedProjectile")
        {
            Destroy(spaceObject.gameObject);
            AddScore(spaceObject);
        }
    }

    private void GenerateShards(SpaceObject enemy)
    {
        GameObject shard1 = Instantiate(EnemyGeneration.GetPrefabByName("Shard"), enemy.transform.position, enemy.transform.rotation);
        shard1.transform.Rotate(0, 0, 45);
        shard1.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);

        GameObject shard2 = Instantiate(EnemyGeneration.GetPrefabByName("Shard"), enemy.transform.position, enemy.transform.rotation);
        shard2.transform.Rotate(0, 0, -45);
        shard2.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);
    }

    private void AddScore(SpaceObject spaceObject)
    {
        _score += spaceObject.Score;
        ScoreChanged.Invoke(_score);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverManager.Display(_score);
    }
}
