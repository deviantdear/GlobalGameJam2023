using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickUp : Interactable
{
    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Food Picked Up");
    }
}
