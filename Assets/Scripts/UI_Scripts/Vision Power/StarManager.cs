using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;

    private int current_stars = 0;
    public int max_stars = 3;
    public Button active_button;

    public Color white_color = Color.white;
    public Camera main_camera;

    private bool is_white = false;


    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        active_button.interactable = false;
    }

    public void AddStar()
    {
        current_stars += 1;
        if (current_stars >= max_stars)
        {
            active_button.interactable = true;
        }
    }

    public void ChangeBackgroundColor()
    {
        if (is_white)
        {
            main_camera.backgroundColor = Color.black;
            is_white = false;
        }
        else
        {
            main_camera.backgroundColor = Color.white;
            is_white = true;
        }
    }


}
