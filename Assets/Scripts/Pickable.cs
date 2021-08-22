using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Pickable : MonoBehaviour
{
    // needs collider
    public string objectName = "Lemon";
    public Sprite icon;

    public string objectText;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // enter interactable state, show UI feedback such as "Press E to interact" 
            collision.gameObject.GetComponent<PlayerInteraction>().CanInteract(this);

        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // enter interactable state, show UI feedback such as "Press E to interact" 
            collision.gameObject.GetComponent<PlayerInteraction>().RemoveInteraction(this);

        }
    }
    public virtual void OnInteract(PlayerInteraction playerInt)
    {
        if (playerInt.inventory.HasSpace())
        {
            playerInt.inventory.Add(playerInt.closestItem);
            playerInt.interactableObjects.Remove(playerInt.closestItem);
            Debug.LogFormat("{0} has been collected.", objectName);
            gameObject.SetActive(false);
        }
    }
}
