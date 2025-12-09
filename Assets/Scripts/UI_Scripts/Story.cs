using UnityEditor.Search;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject Story_BG;
    public GameObject Reward_BG;

    public static bool story_shown = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (story_shown == false)
        {
            Time.timeScale = 0;
            if (Reward_BG != null)
            {
                Reward_BG.SetActive(true);
                Story_BG.SetActive(false);
            }
            else
            {
                ShowStory();
            }
        }
        else
        {
            Time.timeScale = 1;
            if (Reward_BG != null)
            {
                Reward_BG.SetActive(false);
            }
            Story_BG.SetActive(false);
        }
    }

    void ShowStory()
    {
        Story_BG.SetActive(true);
    }
    public void CloseReward()
    {
        Reward_BG.SetActive(false);
        audioManager.PlaySFX(audioManager.ButtonUI);
        ShowStory();
    }

    public void CloseStory()
    {
        Story_BG.SetActive(false);
        audioManager.PlaySFX(audioManager.ButtonUI);
        Time.timeScale = 1;
    }
}
