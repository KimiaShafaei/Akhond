using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{   
   public float speed = 15f; 
    public float maxLifeTime = 5f; 
    AudioManager audioManager;

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
            Debug.LogError("ok bargasht");
        }
        
        Destroy(gameObject); 
    }

    public IEnumerator DeathRoutine()
    {
        audioManager.PlaySFX(audioManager.Death);
        Debug.LogError("audio");
            CameraShake.instance.ShakeCamera(0.55f, 0.6f);
            Debug.LogError("camera shake");
            yield return new WaitForSeconds(0.5f);
            Debug.LogError("nemidonam");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.LogError("scene manager");
            Story.story_shown = true;
            Debug.LogError("story");
    }
}
