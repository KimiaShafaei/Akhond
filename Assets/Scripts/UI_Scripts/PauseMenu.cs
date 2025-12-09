using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void OnPauseClick()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        audioManager.PlaySFX(audioManager.ButtonUI);
    }
    public void OnHomeClick()
    {
        audioManager.PlaySFX(audioManager.ButtonUI);
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void OnResumeClick()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlaySFX(audioManager.ButtonUI);
    }

    public void OnRestartClick()
    {
        audioManager.PlaySFX(audioManager.ButtonUI);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Story.story_shown = true;
    }
    
}
