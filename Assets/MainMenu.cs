using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuUI; // Assign Canvas "pause" ke sini lewat Inspector

    private bool isPaused = false;

    private void Start()
    {
        // Pastikan waktu berjalan normal saat scene mulai
        Time.timeScale = 1f;

        // Sembunyikan pause menu saat game dimulai
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        // Toggle pause saat tekan ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // ▶️ Resume dari pause
    public void OnResumeClick()
    {
        ResumeGame();
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

    // ⏸️ Pause game
    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // ▶️ Mulai permainan dari menu utama
    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene"); // Ganti sesuai nama scene game kamu
        Time.timeScale = 1f;
    }

    // 🔁 Restart permainan
    public void OnRestartClick()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    // 🏠 Kembali ke menu utama
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("StartScene"); // Ganti sesuai nama scene main menu kamu
        Time.timeScale = 1f;
    }

    // 📋 Masuk ke pemilihan stage
    public void OnStageClick()
    {
        SceneManager.LoadScene("StageScene");
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
