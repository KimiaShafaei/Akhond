using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField]
    private ItemDefinition itemDefinition;

    public ItemDefinition GetItemDefinition() => itemDefinition;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public bool TryPickUp(PlayerInventory inventory)
    {
        audioManager.PlaySFX(audioManager.ItemPickup);
        if (inventory.PickUpItem(itemDefinition, this.gameObject))
        {
            return true;
        }
        return false;
    }
    
}
