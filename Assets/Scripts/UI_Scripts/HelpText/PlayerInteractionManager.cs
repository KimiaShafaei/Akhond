using UnityEngine;
using TMPro;

public class PlayerInteractionManager : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI playerPromptText; // متنی که بالای سر پلیر است

    // --- وضعیت های بازی (برای مدیریت مراحل آموزش) ---
    private bool hasMoved = false;
    private bool hasBox = false; // آیا بازیکن باکس را در دست دارد؟
    private bool isNearBox = false;
    private bool isNearShrine = false;

    

    void Start()
    {
        // مرحله ۱: نمایش متن اولیه حرکت
        UpdatePrompt("Use A/D or Arrow Keys to move."); 
    }

    void Update()
    {
        // چک کردن برای اتمام مرحله ۱: حرکت
        if (!hasMoved)
        {
            CheckForMovementInput();
        }

        // چک کردن برای تعامل (دکمه E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForInteraction();
        }
    }

    // --- توابع مدیریت مراحل آموزش ---

    void CheckForMovementInput()
    {
        // چک کردن برای فشار دادن A/D یا کلیدهای جهت‌نما
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || 
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            hasMoved = true;
            // حرکت انجام شد، متن راهنما را بردار
            UpdatePrompt(""); 
        }
    }

    void CheckForInteraction()
    {
        if (isNearBox && !hasBox) // اگر نزدیک باکس هستیم و هنوز آن را برنداشته‌ایم
        {
            HandleBoxPickup();
        }
        else if (isNearShrine && hasBox) // اگر نزدیک Shrine هستیم و باکس را در دست داریم
        {
            HandleBoxPlace();
        }
    }

    void HandleBoxPickup()
    {
        // شبیه‌سازی برداشتن باکس:
        hasBox = true;
        isNearBox = false; // دیگر نزدیک باکس "قابل برداشتن" نیستیم
        

        // *نکته مهم*: در اینجا شما باید گیم آبجکت باکس را حذف (Destroy) یا غیرفعال (SetActive(false)) کنید.
        
        // برداشتن باکس انجام شد، متن را بردار
        UpdatePrompt(""); 
    }

    void HandleBoxPlace()
    {
        // شبیه‌سازی گذاشتن باکس:
        hasBox = false;
        isNearShrine = false; // دیگر نیازی به گذاشتن باکس در Shrine نیست
        
        
        Debug.Log("Box placed in the Shrine! Game completed.");
        
        // گذاشتن باکس انجام شد، متن را بردار
        UpdatePrompt(""); 

        // *نکته مهم*: در اینجا منطق تکمیل معما را پیاده‌سازی کنید.
    }
    
    // --- متد عمومی برای به‌روزرسانی متن ---
    
    public void UpdatePrompt(string message)
    {
        if (playerPromptText != null)
        {
            playerPromptText.text = message;
            // اگر پیام خالی نیست، Canvas را فعال کن
            playerPromptText.gameObject.transform.parent.gameObject.SetActive(!string.IsNullOrEmpty(message));
        }
        
    }

    // --- توابع مدیریت محدوده (فراخوانی از اسکریپت‌های محیطی) ---

    // توسط اسکریپت روی 'باکس' فراخوانی می شود
    public void EnteredBoxRange()
    {
        if (hasMoved && !hasBox) // فقط اگر حرکت کرده و باکس را برنداشته‌ایم
        {
            isNearBox = true;
            UpdatePrompt("Press E to pick up or place the Box.");
        }
    }
    
    public void ExitedBoxRange()
    {
        if (!hasBox) // فقط اگر هنوز باکس را برنداشته‌ایم
        {
            isNearBox = false;
            UpdatePrompt("");
        }
    }

    // توسط اسکریپت روی 'Shrine' فراخوانی می شود
    public void EnteredShrineRange()
    {
        
        if (!hasBox) // فقط اگر باکس را در دست داریم
        {
            isNearShrine = true;
            UpdatePrompt("Press E to place the Box in the Shrine.");
        }
    }
    
    public void ExitedShrineRange()
    {
        if (hasBox) // فقط اگر هنوز باکس را در دست داریم
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