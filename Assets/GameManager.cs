using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float timeLeft = 90f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    public GameObject endGamePanel;
    public GameObject[] stars; // Assign 3 bintang di sini

    private bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        UpdateUI();
        if (endGamePanel != null) endGamePanel.SetActive(false);
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
        endGamePanel.SetActive(true); // Tampilkan UI akhir
        Time.timeScale = 0f; // Hentikan semua pergerakan berbasis waktu

        if (score > 900)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if (score > 500)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if (score > 300)
        {
            stars[0].SetActive(true);
        }

        void ShowStars(int count)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(i < count);
            }
        }
    }
}
