using UnityEngine;
using UnityEngine.InputSystem;
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
    private Star[] all_stars;

    [SerializeField]
    private InputActionReference active_button_action;
    
    public Camera main_camera;

    private bool is_white = false;

    AudioManager audioManager;


    void Awake()
    {
        instance = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        all_stars = FindObjectsOfType<Star>();

        active_button_action.action.Disable();

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
            audioManager.PlaySFX(audioManager.ButtonActivatePower);
            active_button_action.action.Enable();
            active_button_action.action.performed += onActivate;
        }
    }

    public void ChangeBackgroundColor()
    {
        if (is_white)
        {
            main_camera.backgroundColor = Color.black;
            is_white = false;

            ResetAllStars();
        }
        else
        {
            main_camera.backgroundColor = Color.white;
            is_white = true;
        }
    }

    private void onActivate(InputAction.CallbackContext context)
    {
        ChangeBackgroundColor();
    }

    public void ResetAllStars()
    {
        foreach (Star star in all_stars)
        {
            star.ResetStar();
        }

        current_stars = 0;

        Star1.gameObject.SetActive(false);
        Star2.gameObject.SetActive(false);
        Star3.gameObject.SetActive(false);

        active_button_action.action.Disable();
    }
}
