using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}
