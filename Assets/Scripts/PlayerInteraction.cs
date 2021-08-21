using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    bool canInteract = false;
    bool canDrag= false;

    // Set in editor
    public Transform dropPoint;

    [HideInInspector] public List<Pickable> interactableObjects = null;
    [HideInInspector] public List<Dragable> dragableObjects = null;
    public Pickable closestItem = null;
    public Dragable closestDragable = null;
    public Dragable carriedDragable = null; //currently carrying
    public PlayerController plController;

    private int TriggerCount = 0;
    private bool isCollided = false;
    private bool isDraging = false;


    //!!!!!! may be change UI
    public Image eButton;
    public TextMeshProUGUI InteractableTextTMP;
    public GameObject spaceButton;

    public Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        interactableObjects = new List<Pickable>();
        dragableObjects = new List<Dragable>();
        plController = FindObjectOfType<PlayerController>();

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

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canDrag && dragableObjects.Count > 0 && !isDraging) //Drag grab
            {
                isDraging = true;
                carriedDragable = closestDragable;
                carriedDragable.OnDrag(this);
                plController.moveSpeed /= 4;

            }
            else if(isDraging)
            {
                carriedDragable.LeaveDrag(this);
                carriedDragable = null;
                isDraging = false;
                plController.moveSpeed *= 4;
                
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
            FindClosestItem();
        }

        if (dragableObjects.Count > 0)
        {
            FindClosestDrag();
        }

        if (isCollided)
        {   
            if(closestItem != null)
                InteractableTextTMP.text = closestItem.objectText;
        }
    }


    public void CanInteract(Pickable item)
    {
        canInteract = true;
        interactableObjects.Add(item);

        // UI part 
        TriggerCount++;
        isCollided = true;
        eButton.GetComponent<Image>().enabled = true;

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

        // UI part 
        TriggerCount--;
        if (TriggerCount == 0)
        {
            isCollided = false;
            InteractableTextTMP.text = null;
            eButton.GetComponent<Image>().enabled = false;
        }
    }
    
   
    private void FindClosestItem()
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
    private void FindClosestDrag()
    {

        float closestDist = 9999;
        Dragable currClosest = dragableObjects[0];

        for (int i = 0; i < dragableObjects.Count; i++)
        {
            var dist = Vector2.Distance(transform.position, dragableObjects[i].transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                currClosest = dragableObjects[i];
            }
        }
        closestDragable = currClosest;
    }

    //Drag

    public void CanDrag(Dragable item)
    {
        
        canDrag= true;
        dragableObjects.Add(item);
       
        // UI part 
        spaceButton.SetActive(true);


    }
    public void RemoveCanDrag(Dragable item)
    {

        if (dragableObjects.Contains(item))
        {
            dragableObjects.Remove(item);
            if (dragableObjects.Count == 0)
            {
                canDrag = false;
                spaceButton.SetActive(false);
            }
        }
   

    }



}
