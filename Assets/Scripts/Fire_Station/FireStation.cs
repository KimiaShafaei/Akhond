using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireStation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float toggle_time = 2f;
    private bool is_on = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ToggleRoutine());
    }

    private System.Collections.IEnumerator ToggleRoutine()
    {
        while (true)
        {
            ToggleState();
            yield return new WaitForSeconds(toggle_time);
        }
    }

    void ToggleState()
    {
        is_on = !is_on;
        animator.SetBool("IsOn", is_on);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!is_on)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.Death);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}