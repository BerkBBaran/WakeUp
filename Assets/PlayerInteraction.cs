using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool canInteract = false;
    public List<Pickable> interactableObjects = null;
    public Pickable closestItem = null;

    Inventory inventory;
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        interactableObjects = new List<Pickable>();

        if (inventory == null) 
        {
            Debug.LogError("Missing inventory script in scene!!");
        }
    }

    public void CanInteract(Pickable item)
    {
        canInteract = true;
        interactableObjects.Add(item);

        // calculate closest distance item
    }
    public void RemoveInteraction(Pickable item)
    {
        if(interactableObjects.Contains(item))
        {
            interactableObjects.Remove(item);
            if(interactableObjects.Count == 0)
            {
                canInteract = false;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(canInteract && interactableObjects.Count > 0)
            {
                if (inventory.HasSpace())
                {
                    inventory.Add(closestItem);
                    interactableObjects.Remove(closestItem);

                    closestItem.OnCollect(); // destroys the object.
                }
            }
        }
    }
}
