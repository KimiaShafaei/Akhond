using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI;

    public void OnPauseClick()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnHomeClick()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

    public void OnResumeClick()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    
}
