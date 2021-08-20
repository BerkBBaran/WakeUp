using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// game controller/manager
public class Inventory : MonoBehaviour
{

    // UI icon reference.
    public SpriteRenderer itemIcon;

    // one slot
    // item of type pickable
    public Pickable item = null;


    // pickable has actions in itself

    // Add func
    public void Add(Pickable item)
    {
        this.item = item;

        // show this item's icon on UI
        itemIcon.sprite = item.icon;
    }

    // TODO Remove func

    // has item x?
    public bool HasSpace()
    {
        return item == null;
    }

}
