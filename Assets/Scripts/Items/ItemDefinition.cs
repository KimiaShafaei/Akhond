using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/ItemDefinition")]
public class ItemDefinition : ScriptableObject
{
    [Header("Item Info")]
    public string item_name;
    public string item_description;

    [Header("Visuals")]
    public Sprite world_sprite;
}
