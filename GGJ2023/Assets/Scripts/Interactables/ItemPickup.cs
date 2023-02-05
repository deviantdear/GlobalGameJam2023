using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override bool Interact()
    {
        if (hasInteracted)
            return false;
        PickUp();
        return base.Interact();
    }

    void PickUp()
    {
        Debug.Log("Picking Up " + item.name);


        //Add item to inventory or update UI, do callback

        bool wasPickedUp = true;
        if (wasPickedUp)
        {        
            //Play Sound
            //heal Player

            Destroy(gameObject);
        }
    }
}
