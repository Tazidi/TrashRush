using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Untuk mulai permainan dari menu utama
    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene"); // Ganti "SampleScene" dengan nama scene permainanmu
        Time.timeScale = 1f; // Pastikan waktu berjalan normal saat masuk game
    }

    // Untuk keluar dari aplikasi
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 🔁 Untuk me-restart permainan dari Game Over atau dalam game
    public void OnRestartClick()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f; // Reset waktu jika sebelumnya di-pause
    }

    // 🏠 Kembali ke menu utama dari scene manapun
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("StartScene"); // Ganti "MainMenu" dengan nama scene menu utama kamu
        Time.timeScale = 1f;
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnStageClick()
    {
        SceneManager.LoadScene("StageScene"); 
    }
}
