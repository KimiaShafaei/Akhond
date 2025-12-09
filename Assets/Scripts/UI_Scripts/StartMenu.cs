using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene("Level1");
        audioManager.PlaySFX(audioManager.ButtonUI);
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene("Credits");
        audioManager.PlaySFX(audioManager.ButtonUI);
    }
    public void OnExitClick()
    {
        Application.Quit();
        audioManager.PlaySFX(audioManager.ButtonUI);
    }
}
