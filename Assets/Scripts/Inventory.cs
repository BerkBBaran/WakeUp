using UnityEngine;
using UnityEngine.UI;

// game controller/manager
public class Inventory : MonoBehaviour
{
    //Editor
    public Color transparent;

    // UI icon reference.
    public Image itemIcon;
    

    // one slot
    // item of type pickable
    public Pickable item = null;

    bool hasSpace = true;
    private Sprite defaultSprite;
    // pickable has actions in itself

    private void Awake()
    {
        defaultSprite = itemIcon.sprite;
    }
    // Add func
    public void Add(Pickable pickedItem)
    {
        item = pickedItem;
        hasSpace = false;
        Debug.Log("Player has item: " + item.objectName);

        // show this item's icon on UI
        itemIcon.sprite = pickedItem.icon;
        itemIcon.color = Color.white;
    }

    // TODO Remove func
    public void RemoveItem()
    {
        item = null;
        hasSpace = true;

        // show this item's icon on UI
        itemIcon.sprite = defaultSprite;
        itemIcon.color = transparent;

    }
    // has item x?
    public bool HasSpace()
    {
        return hasSpace;
    }

}
