using UnityEngine;
using UnityEngine.SceneManagement;
using Movement;

/// <summary>
/// �����, �������������� ������� �������
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerPositionView _playerPosition;
    [SerializeField] private DisplayToInterface _interfaceDisplayer;
    [SerializeField] private GameObject _borders;  
    [SerializeField] private GameOver _gameOverManager;

    private int _score = 0;    

    void Start()
    {
        CollisionManager collisionManager = CollisionManager.GetInstanse();
        collisionManager.SpaceObjectDestroyedEvent.AddListener(AddScore);
        collisionManager.PlayerCollidedEvent.AddListener(GameOver);        
    }
         
    private void AddScore(int score)
    {
        _score += score;
        _interfaceDisplayer.SetScore(_score);        
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
