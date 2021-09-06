using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Movement;

/// <summary>
/// Класс, контролирующий игровой процесс
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerPositionView _playerPosition;
    [SerializeField] private DisplayToInterface _interfaceDisplayer;
    [SerializeField] private GameObject _borders;  
    [SerializeField] private GameOver _gameOverManager;

    private int _score = 0;

    public UnityEvent<Vector2> PlayerPositionChanged = new UnityEvent<Vector2>();
    public UnityEvent<int> ScoreChanged = new UnityEvent<int>();

    void Start()
    {
        CollisionManager collisionManager = CollisionManager.GetInstanse();
        collisionManager.SpaceObjectDestroyedEvent.AddListener(AddScore);
        collisionManager.PlayerCollidedEvent.AddListener(GameOver);

        ScoreChanged.AddListener(_interfaceDisplayer.SetScore);
    }
   
    void Update()
    {
        PlayerPositionChanged.Invoke(_playerPosition.CurrentPositon);
    }
    
    private void AddScore(int score)
    {
        _score += score;
        ScoreChanged.Invoke(_score);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverManager.Display(_score);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene"); 
    }
}
