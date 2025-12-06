using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final_door : MonoBehaviour
{
    [SerializeField]
    private string scene_name;
    [SerializeField]
    float open_anim_time = 2.0f;
    [SerializeField]
    float close_anim_time = 2.0f;

    private Animator animator;
    private Collider2D door_collider;

    public GameObject player;

    private bool is_open = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        door_collider = GetComponent<Collider2D>();

        if (door_collider != null)
        {
            door_collider.enabled = true;
        }
    }

    public void Open()
    {
        if (is_open == true)
        {
            return;
        }

        is_open = true;

        if (animator != null)
        {
            animator.SetTrigger("Open");
        }

        StartCoroutine(DisableCollider());
        door_collider.isTrigger = true;
    }

    private IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(open_anim_time);

        if (door_collider != null)
        {
            door_collider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && is_open == true)
        {
            Debug.Log("Loading Scene: " + scene_name);
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        if (animator != null)
        {
            player.SetActive(false);
            animator.SetTrigger("Close");
        }

        yield return new WaitForSeconds(close_anim_time);

        SceneManager.LoadScene(scene_name);
    }
}
