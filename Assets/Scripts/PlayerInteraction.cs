using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool canInteract = false;

    // Set in editor
    public Transform dropPoint;

    [HideInInspector] public List<Pickable> interactableObjects = null;
    public Pickable closestItem = null;

    public Inventory inventory;
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        interactableObjects = new List<Pickable>();

        if (inventory == null) 
        {
            Debug.LogError("Missing inventory script in scene!!");
        }
    }
    private void Start()
    {

    }
    private void Update()
    {
        // Pick up item
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (canInteract && interactableObjects.Count > 0)
            {
                closestItem.OnInteract(this);
            }
        }

        // Drop item
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (!inventory.HasSpace())
            {
                // remove from inventory
                // drop to ground
                inventory.item.transform.position = dropPoint.position;
                inventory.item.gameObject.SetActive(true);

                inventory.RemoveItem();
            }
        }

        if (interactableObjects.Count > 0)
        {
            // calculate closest distance item
            float closestDist = 9999;
            Pickable currClosest = interactableObjects[0];

            for (int i = 0; i < interactableObjects.Count; i++)
            {
                var dist = Vector2.Distance(transform.position, interactableObjects[i].transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    currClosest = interactableObjects[i];
                }
            }
            closestItem = currClosest;
        }
    }


    public void CanInteract(Pickable item)
    {
        canInteract = true;
        interactableObjects.Add(item);

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
 

   
}