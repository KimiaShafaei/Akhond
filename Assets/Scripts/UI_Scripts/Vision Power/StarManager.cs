using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;

    [SerializeField]
    private Image Star1;
    [SerializeField]
    private Image Star2;
    [SerializeField]
    private Image Star3;    

    private int current_stars = 0;
    public int max_stars = 3;
    public Button active_button;
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
        active_button.gameObject.SetActive(false);

        Star1.gameObject.SetActive(false);
        Star2.gameObject.SetActive(false);
        Star3.gameObject.SetActive(false);
    }

    public void AddStar()
    {
        current_stars += 1;
        if (current_stars == 1)
        {
            Star1.gameObject.SetActive(true);
        }
        if (current_stars == 2)
        {
            Star2.gameObject.SetActive(true);
        }
        if (current_stars == 3)
        {
            Star3.gameObject.SetActive(true);
        }

        if (current_stars >= max_stars)
        {
            active_button.interactable = true;
            active_button.gameObject.SetActive(true);
        }
    }

    public void ChangeBackgroundColor()
    {
        if (is_white)
        {
            main_camera.backgroundColor = Color.black;
            is_white = false;

            active_button.interactable = false;
            active_button.gameObject.SetActive(false);
            current_stars = 0;
        }
        else
        {
            main_camera.backgroundColor = Color.white;
            is_white = true;
        }
    }


}
