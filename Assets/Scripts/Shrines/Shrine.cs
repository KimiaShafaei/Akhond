using UnityEngine;

public class Shrine : MonoBehaviour
{
    [Header("Shrine Info")]
    [SerializeField]
    private string shrine_name;

    [SerializeField]
    private GameObject door_object;

    [SerializeField]
    private GameObject star_object;

    private bool is_activated = false;
    private SpriteRenderer sprite_renderer;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();

        if (star_object != null)
        {
            star_object.SetActive(false);
        }
    }

    public bool TryOfferItem(ItemDefinition item)
    {
        if (is_activated == true | item == null)
        {
            return false;
        }

        if (item.Accept_by_shrine_name == this.shrine_name)
        {
            ActivateShrine();
            return true;
        }

        else
        {
            return false;
        }
    }

    private void ActivateShrine()
    {
        audioManager.PlaySFX(audioManager.ShrineActivate);
        
        is_activated = true;

        if (door_object != null)
        {
            final_door door_script = door_object.GetComponent<final_door>();
            if (door_script != null)
            {
                door_script.Open();
            }

            middle_door middle_door_script = door_object.GetComponent<middle_door>();
            if (middle_door_script != null)
            {
                middle_door_script.Open();
            }
        }

        if (star_object != null)
        {
            star_object.SetActive(true);
        }
    }
}
