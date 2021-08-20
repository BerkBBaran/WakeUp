using UnityEngine;

// game controller/manager
public class Inventory : MonoBehaviour
{

    // UI icon reference.
    public SpriteRenderer itemIcon;

    // one slot
    // item of type pickable
    public Pickable item = null;

    bool hasSpace = true;

    // pickable has actions in itself

    // Add func
    public void Add(Pickable pickedItem)
    {
        item = pickedItem;
        hasSpace = false;
        Debug.Log("Player has item: " + item.objectName);

        // show this item's icon on UI
        itemIcon.sprite = pickedItem.icon;
    }

    // TODO Remove func
    public void RemoveItem()
    {
        item = null;
        hasSpace = true;

        // show this item's icon on UI
        itemIcon.sprite = null;
    }
    // has item x?
    public bool HasSpace()
    {
        return hasSpace;
    }

}
