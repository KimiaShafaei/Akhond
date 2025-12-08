using UnityEditor.Search;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject Story_BG;
    public GameObject Reward_BG;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

    void ShowStory()
    {
        Story_BG.SetActive(true);
    }
    public void CloseReward()
    {
        Reward_BG.SetActive(false);
        ShowStory();
    }

    public void CloseStory()
    {
        Story_BG.SetActive(false);
        Time.timeScale = 1;
    }
}
