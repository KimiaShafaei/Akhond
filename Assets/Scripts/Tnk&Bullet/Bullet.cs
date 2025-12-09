using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{   
   public float speed = 15f; 
    public float maxLifeTime = 5f; 
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>(); 

    if (rb != null)
    {
        rb.linearVelocity = Vector2.left * speed; 
    }

    Destroy(gameObject, maxLifeTime);
}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.collider.gameObject;
        
        if (otherObject.CompareTag("Player"))
        {
            StartCoroutine(DeathRoutine());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator DeathRoutine()
    {
        audioManager.PlaySFX(audioManager.Death);
        CameraShake.instance.ShakeCamera(0.55f, 0.6f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Story.story_shown = true;
        Destroy(gameObject);

    }
}
