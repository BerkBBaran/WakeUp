using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Pickable
{
    // limonata bardagi
    // bardak -> limon, su, seker
    public List<string> requiredItems = new List<string> { "Lemon", "Sugar" };

    public Sprite completedSprite; // sprite that is shown when the item is complete: lemonade

    bool isComplete = false;

    Inventory inventory;
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    public override void OnInteract(PlayerInteraction playerInt)
    {
        // check player inventory
        // if has one of the required items, use it, switch to another state.
        // if all req's are met, go on to final state -> turns into lemonade.

        if (isComplete)
        {

        }
        else // still has required items
        {
            string itemName = inventory.item.objectName;
            if (requiredItems.Contains(itemName))
            {
                // found a required item, use it for this Goal
                inventory.RemoveItem();
                requiredItems.Remove(itemName);
                if (requiredItems.Count == 0)
                {
                    isComplete = true;
                    // this goal is complete, maybe add the combined/completed version to inventory for use?
                    inventory.Add(this);

                    // maybe turn of sprite
                    this.gameObject.SetActive(false);
                }
            }
        }

        // decision parameters:
        // is in inventory?
        // has all requirements met?
    }
}
