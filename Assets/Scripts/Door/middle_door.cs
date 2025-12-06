using UnityEngine;

public class middle_door : MonoBehaviour
{
    private Animator animator;
    private Collider2D door_collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        door_collider = GetComponent<Collider2D>();

        if (door_collider != null)
        {
            door_collider.isTrigger = false;
        }
    }

    public void Open()
    {
        if (animator != null)
        {
            animator.SetTrigger("Open");
        }

        if (door_collider != null)
        {
            door_collider.isTrigger = true;
        }
    }
}
