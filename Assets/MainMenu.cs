using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuUI; // Tarik Canvas "pause" ke sini di Inspector

    private bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // ▶️ Resume game
    public void OnResumeClick()
    {
        ResumeGame();
    }

    // ⏸️ Pause game via tombol UI
    public void OnPauseClick()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ▶️ Mulai permainan dari menu utama
    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    // 🔁 Restart game
    // 🔁 Restart game berdasarkan scene aktif
    public void OnRestartClick()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }


    // 🏠 Kembali ke menu utama
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }

    // 📋 Masuk ke scene pemilihan stage
    public void OnStageClick()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void OnStage2Click()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void OnStage3Click()
    {
        SceneManager.LoadScene("Stage3");
    }

    // ❌ Keluar dari game
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
