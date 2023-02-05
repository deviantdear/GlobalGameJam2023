using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickUp : Interactable
{
    [SerializeField] SpriteRenderer m_sprite;
    [SerializeField] Sprite m_Eaten;
    public override bool Interact()
    {
        Debug.Log("Interacting");
        if (hasInteracted)
            return false;
        
        PickUp();
        return true;
    }

    void PickUp()
    {
        Debug.Log("Food Picked Up");
        m_sprite.sprite = m_Eaten;
        hasInteracted = true;
    }
}
