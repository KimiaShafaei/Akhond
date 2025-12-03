using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private ItemDefinition itemDefinition;

    public ItemDefinition GetItemDefinition() => itemDefinition;

    public bool TryPickUp(PlayerInventory inventory)
    {
        if (inventory.PickUpItem(itemDefinition, this.gameObject))
        {
            return true;
        }
        return false;
    }
    
}
