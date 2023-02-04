﻿using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Items")]
public class Item : ScriptableObject
{
    // Blueprint that all other scriptable object will inherit from

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
    public virtual void Use()
    {
        //uses item, something happens

        Debug.Log("Using " + name);
    }

    public void Remove()
    {
        // Remove(this); //Calls the Remove method callback
    }


}
