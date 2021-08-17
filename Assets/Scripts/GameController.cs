using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInformationUpdating _playerInformationUpdating;
    [SerializeField] private DisplayToInterface _interfaceDisplayer;
    [SerializeField] private GameObject _borders;  
    [SerializeField] private GameOver _gameOverManager;

    private int _score = 0;

    public UnityEvent<Vector2> PlayerPositionChanged = new UnityEvent<Vector2>();
    public UnityEvent<int> ScoreChanged = new UnityEvent<int>();

    void Start()
    {        
        ScoreChanged.AddListener(_interfaceDisplayer.SetScore);
    }
   
    void Update()
    {
        PlayerPositionChanged.Invoke(_playerInformationUpdating.PlayerInformation.Position);
    }

    public void Collision(SpaceObject spaceObject, Collider2D other)
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
        GameObject shard1 = Instantiate(PrefabsManager.GetPrefabByName("Shard"), enemy.transform.position, enemy.transform.rotation);
        shard1.transform.Rotate(0, 0, 45);
        shard1.GetComponent<SpaceObject>().EnemyCollisionEvent.AddListener(Collision);

        GameObject shard2 = Instantiate(PrefabsManager.GetPrefabByName("Shard"), enemy.transform.position, enemy.transform.rotation);
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
