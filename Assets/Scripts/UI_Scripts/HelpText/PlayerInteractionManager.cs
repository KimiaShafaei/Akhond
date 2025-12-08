using UnityEngine;
using TMPro;

public class PlayerInteractionManager : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI playerPromptText;

    private bool hasMoved = false;
    private bool hasBox = false;
    private bool isNearBox = false;
    private bool isNearShrine = false;

    

    void Start()
    {
        UpdatePrompt("Use A/D or Arrow Keys to move.\n Press Space to jump."); 
    }

    void Update()
    {
        if (!hasMoved)
        {
            CheckForMovementInput();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForInteraction();
        }
    }


    void CheckForMovementInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || 
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            hasMoved = true;
            UpdatePrompt(""); 
        }
    }

    void CheckForInteraction()
    {
        if (isNearBox && !hasBox)
        {
            HandleBoxPickup();
        }
        else if (isNearShrine && hasBox)
        {
            HandleBoxPlace();
        }
    }

    void HandleBoxPickup()
    {
        hasBox = true;
        isNearBox = false;
        
        UpdatePrompt(""); 
    }

    void HandleBoxPlace()
    {
        hasBox = false;
        isNearShrine = false;
        
        
        Debug.Log("Box placed in the Shrine! Game completed.");
        
        UpdatePrompt(""); 
    }
        
    public void UpdatePrompt(string message)
    {
        if (playerPromptText != null)
        {
            playerPromptText.text = message;
            playerPromptText.gameObject.transform.parent.gameObject.SetActive(!string.IsNullOrEmpty(message));
        }
        
    }

    public void EnteredBoxRange()
    {
        if (hasMoved && !hasBox) 
        {
            isNearBox = true;
            UpdatePrompt("Press E to pick up or place the Box.");
        }
    }
    
    public void ExitedBoxRange()
    {
        if (!hasBox) 
        {
            isNearBox = false;
            UpdatePrompt("");
        }
    }

    public void EnteredShrineRange()
    {
        
        if (!hasBox) 
        {
            isNearShrine = true;
            UpdatePrompt("Press E to place the Box in the Shrine.");
        }
    }
    
    public void ExitedShrineRange()
    {
        if (hasBox) 
        {
            isNearShrine = false;
            UpdatePrompt("");
        }
        if (!hasBox)
        {
            isNearBox = false;
            UpdatePrompt("");

        }
    }

    
}