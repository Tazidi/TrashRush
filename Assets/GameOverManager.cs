using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject[] stars;
    public TextMeshProUGUI finalScoreText;

    public GameObject continueButton; // 🎯 Tarik tombol Continue ke sini di Inspector
    public GameObject restartButton;  // 🎯 Tarik tombol Restart ke sini di Inspector

    public string[] stageNames = { "SampleScene", "Stage2", "Stage3" };

    void Start()
    {
        Time.timeScale = 1f;

        int score = GameData.finalScore;
        int starCount = GameData.starCount;

        if (finalScoreText != null)
            finalScoreText.text = "Score: " + score;

        foreach (GameObject star in stars)
            star.SetActive(false);

        for (int i = 0; i < stars.Length; i++)
        {
            if (i < starCount)
                stars[i].SetActive(true);
        }

        string currentScene = GameData.lastPlayedScene;
        bool isLastStage = currentScene == stageNames[stageNames.Length - 1];

        if (continueButton != null)
            continueButton.SetActive(!isLastStage); // ❌ Sembunyikan continue di stage terakhir

        if (restartButton != null)
            restartButton.SetActive(true); // ✅ Selalu tampil
    }

    public void OnContinueClick()
    {
        string currentScene = GameData.lastPlayedScene;

        for (int i = 0; i < stageNames.Length - 1; i++)
        {
            if (stageNames[i] == currentScene)
            {
                SceneManager.LoadScene(stageNames[i + 1]);
                return;
            }
        }

        Debug.Log("Sudah di stage terakhir atau nama scene tidak cocok!");
    }

    // 🔁 Restart stage yang terakhir dimainkan
    public void OnRestartClick()
    {
        if (!string.IsNullOrEmpty(GameData.lastPlayedScene))
        {
            SceneManager.LoadScene(GameData.lastPlayedScene);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogWarning("lastPlayedScene kosong! Tidak bisa restart.");
        }
    }

}
