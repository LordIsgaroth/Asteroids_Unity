using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� ���� ����� ����
/// </summary>
public class GameOver : MonoBehaviour
{
    [SerializeField] Text _scoreText;

    public void Display(int score)
    {
        gameObject.SetActive(true);
        _scoreText.text = $"Score: {score}";
    }    
}
