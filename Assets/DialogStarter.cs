using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : Pickable
{ 
    public override void OnInteract(PlayerInteraction playerInt)
    {
        var dialogControl = FindObjectOfType<DialogController>();
        if(dialogControl != null)
        {
            dialogControl.StartTyping();
        }
    }
}
