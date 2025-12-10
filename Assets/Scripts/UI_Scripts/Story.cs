using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject Story_BG;
    public GameObject Reward_BG;

    AudioManager audioManager;

    string storyKey;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        storyKey = "StoryShown_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        bool story_shown = PlayerPrefs.GetInt(storyKey, 0) == 1;

        if (!story_shown)
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
                Reward_BG.SetActive(false);

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

        PlayerPrefs.SetInt(storyKey, 1);  
    }
}