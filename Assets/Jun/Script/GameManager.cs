using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

    private int score;
    private float gameTime;
    private float difficulty;
    
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
        difficulty = 0;
        UpdateUI();
    }

    private void Update()
    {
        AddScoreBySecond();
        IncreaseDifficultyBySecond();
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

    private void IncreaseDifficultyBySecond() {
        difficulty += Time.deltaTime;
    }

    public int GetDifficulty() {
        return (int)difficulty;
    }
    
    private void AddScoreBySecond()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= 1f)
        {
            AddScore(1);
            gameTime -= 1f;
        }
    }
    

    private void UpdateUI()
    {
        scoreText.text = "Score : " + score;
    }
}
