using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplaying : MonoBehaviour
{
    [SerializeField] Text _scoreText;

    public void Display(int score)
    {
        gameObject.SetActive(true);
        _scoreText.text = $"Score: {score}";
    }
}
