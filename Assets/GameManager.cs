using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float timeLeft = 90f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    private bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            EndGame();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();

        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
    }

    void EndGame()
    {
        gameEnded = true;

        // Simpan skor dan jumlah bintang ke GameData
        GameData.finalScore = score;

        if (score > 900)
            GameData.starCount = 3;
        else if (score > 500)
            GameData.starCount = 2;
        else if (score > 300)
            GameData.starCount = 1;
        else
            GameData.starCount = 0;

        // Pindah ke scene Game Over
        SceneManager.LoadScene("GameOverScene"); // Ganti dengan nama scene kamu
    }
}

// iwansyahputra