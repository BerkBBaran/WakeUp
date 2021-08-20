using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    // needs collider
    public string objectName = "Lemon";
    public Sprite icon;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // enter interactable state, show UI feedback such as "Press E to interact" 
            collision.gameObject.GetComponent<PlayerInteraction>().CanInteract(this);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // enter interactable state, show UI feedback such as "Press E to interact" 
            collision.gameObject.GetComponent<PlayerInteraction>().RemoveInteraction(this);

        }
    }
    public void OnCollect()
    {
        Debug.LogFormat("{0} has been collected.", objectName);
        Destroy(this.gameObject);
    }
}

// pickable -- limon 
// bardak -> limon, su, seker

public class Goal
{
    List<string> requiredItems = new List<string>{ "Lemon", "Sugar" };

}