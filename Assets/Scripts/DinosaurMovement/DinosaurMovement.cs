using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DinosaurMovement : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;

    public float speed = 2.0f;
    private Vector3 targetPosition;

    private Animator animator;
        AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        targetPosition = pointB;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        bool MoveRight = targetPosition.x > transform.position.x;
        animator.SetBool("MoveRight", MoveRight);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (targetPosition == pointB)
            {
                targetPosition = pointA;
            }
            else if (targetPosition == pointA)
            {
                targetPosition = pointB;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit! Starting Restart Process.");
            StartCoroutine(DeathRoutine());
        }
    }


        public IEnumerator DeathRoutine()
    {
        audioManager.PlaySFX(audioManager.Death);
        CameraShake.instance.ShakeCamera(0.55f, 0.6f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Story.story_shown = true;
    }
}
