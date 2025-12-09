using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void OnExitClick()
    {
        SceneManager.LoadScene("StartMenu");
        audioManager.PlaySFX(audioManager.ButtonUI);
    }
}
