using UnityEngine;

public class InteractionTriggerReporter : MonoBehaviour
{
    [Header("Reporter Type")]
    // تعیین می کند که این تریگر مربوط به باکس است یا Shrine
    public bool isBoxTrigger = true; 
    
    private PlayerInteractionManager playerManager;

    void Start()
    {
        playerManager = FindFirstObjectByType<PlayerInteractionManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && playerManager != null)
        {
            if (isBoxTrigger)
            {
                playerManager.EnteredBoxRange();
            }
            else
            {
                playerManager.EnteredShrineRange();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerManager != null)
        {
            if (isBoxTrigger)
            {
                playerManager.ExitedBoxRange();
            }
            else
            {
                playerManager.ExitedShrineRange();
            }
        }
    }
}