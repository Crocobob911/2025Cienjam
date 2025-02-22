using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager INSTANCE;

    private int score;
    private float timer;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [SerializeField] private SceneController sceneController;
    

    public void Awake()
    {
        if(INSTANCE == null) INSTANCE = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        score = 0;
        UpdateUI();
    }

    private void Update()
    {
        AddScoreBySecond();
    }

    public void AddScore(int score)
    {
        this.score += score;
        UpdateUI();
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("Score", score);
        sceneController.LoadScene("Game Over");

    }

    private void AddScoreBySecond()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            AddScore(1);
            timer -= 1f;
        }
    }
    

    private void UpdateUI()
    {
        scoreText.text = "Score : " + score;
    }
}
