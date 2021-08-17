using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text _scoreText;

    public void Display(int score)
    {
        gameObject.SetActive(true);
        _scoreText.text = $"Score: {score}";
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene");
    }
}
