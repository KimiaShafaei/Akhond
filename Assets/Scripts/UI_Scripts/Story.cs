using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject Story_BG;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Story_BG.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseStory()
    {
        Story_BG.SetActive(false);
        Time.timeScale = 1;
    }
}
