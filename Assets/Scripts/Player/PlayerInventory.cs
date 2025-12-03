using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Transform carry_point;

    [SerializeField]
    private float drop_distance = 0.5f;

    private ItemDefinition current_item;
    private GameObject carried_item_object;

    public bool HasItem() => current_item != null;    

    public bool PickUpItem(ItemDefinition item, GameObject item_object)
    {
        if (current_item != null)
            return false;

        current_item = item;
        carried_item_object = item_object;

        carried_item_object.transform.SetParent(carry_point);
        carried_item_object.transform.localPosition = Vector3.zero;

        carried_item_object.GetComponent<Collider2D>().enabled = false;
        return true;
    }

    public void DropItem()
    {
        if (current_item == null)
            return;

        float facing_direction = transform.localScale.x;

        Vector3 drop_position = transform.position + new Vector3(facing_direction * drop_distance, 0, 0);

        carried_item_object.transform.SetParent(null);
        carried_item_object.transform.position = drop_position;
        carried_item_object.GetComponent<Collider2D>().enabled = true;

        current_item = null;
        carried_item_object = null;
    }
}