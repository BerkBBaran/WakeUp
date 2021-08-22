using UnityEngine;

public class MonitorPickup : Pickable
{
    public GameObject HeartRateMonitor;
    public override void OnInteract(PlayerInteraction playerInt)
    {
        playerInt.interactableObjects.Remove(playerInt.closestItem);
        Debug.LogFormat("{0} has been collected.", objectName);
        gameObject.SetActive(false);

        HeartRateMonitor.SetActive(true);
    }
}
