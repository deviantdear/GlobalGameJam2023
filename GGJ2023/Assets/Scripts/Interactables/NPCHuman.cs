using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHuman : Interactable
{
    CharacterStats myStats; //References NPC Stats

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();

    }
}
   
