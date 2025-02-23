using System;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = score + "pt";
    }
}
