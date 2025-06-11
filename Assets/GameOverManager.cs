using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject[] stars; // Drag Stars1, Stars2, Stars3 di Inspector
    public TextMeshProUGUI finalScoreText; // Drag teks skor akhir ke sini
   public string[] stageNames = { "SampleScene", "Stage2", "Stage3" };
 // Daftar nama stage berurutan

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

    // ▶️ Lanjut ke stage berikutnya
    public void OnContinueClick()
{
    string currentScene = SceneManager.GetActiveScene().name;
    Debug.Log("Current Scene: " + currentScene);

    for (int i = 0; i < stageNames.Length - 1; i++)
    {
        if (stageNames[i] == currentScene)
        {
            string nextStage = stageNames[i + 1];
            Debug.Log("Loading next stage: " + nextStage);
            SceneManager.LoadScene(nextStage);
            return;
        }
    }

    Debug.Log("Sudah di stage terakhir atau nama scene tidak cocok!");
}

