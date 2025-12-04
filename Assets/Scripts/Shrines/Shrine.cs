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
        is_activated = true;

        if (door_object != null)
        {
            Animator door_animator = door_object.GetComponent<Animator>();
            if (door_animator != null)
            {
                door_animator.SetTrigger("Open");
                Collider2D door_collider = door_object.GetComponent<Collider2D>();
                if (door_collider != null)
                {
                    door_collider.enabled = false;
                }
            }
        }

        if (star_object != null)
        {
            star_object.SetActive(true);
        }
    }
}
