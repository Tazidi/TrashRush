using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject[] stars; // Drag Stars1, Stars2, Stars3 di Inspector
    public TextMeshProUGUI finalScoreText; // Drag teks skor akhir ke sini

    void Start()
    {
        Time.timeScale = 1f; // Pastikan game tidak dibekukan

        int score = GameData.finalScore;
        int starCount = GameData.starCount;

        if (finalScoreText != null)
        {
            finalScoreText.text = "Score: " + score;
        }

        // Matikan semua bintang
        foreach (GameObject star in stars)
        {
            star.SetActive(false);
        }

        // Tampilkan bintang sesuai starCount
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < starCount)
            {
                stars[i].SetActive(true);
            }
        }
    }
}
//  tes pul git