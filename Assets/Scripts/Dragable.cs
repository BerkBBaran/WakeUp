using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInteraction>().CanDrag(this);

        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // enter interactable state, show UI feedback such as "Press E to interact" 
            collision.gameObject.GetComponent<PlayerInteraction>().RemoveCanDrag(this);

        }
    }

    public void OnDrag(PlayerInteraction playerInt)
    {
        transform.parent = playerInt.transform;
    }
    public void LeaveDrag(PlayerInteraction playerInt)
    {
        transform.parent = null;
    }
}
