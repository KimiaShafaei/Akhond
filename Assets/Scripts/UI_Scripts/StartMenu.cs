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
        ResetStories();
        PlayerPrefs.DeleteKey("StoryShown_Level1");
        SceneManager.LoadScene("Level1");
        audioManager.PlaySFX(audioManager.ButtonUI);
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene("Credit");
        audioManager.PlaySFX(audioManager.ButtonUI);
    }
    public void OnExitClick()
    {
        Application.Quit();
        audioManager.PlaySFX(audioManager.ButtonUI);
    }
    void ResetStories()
    {
        PlayerPrefs.DeleteKey("StoryShown_Level1");
        PlayerPrefs.DeleteKey("StoryShown_Level2");
        PlayerPrefs.DeleteKey("StoryShown_Level3");
    }
}
