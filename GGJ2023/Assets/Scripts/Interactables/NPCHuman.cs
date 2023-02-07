using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHuman : Interactable
{
    CharacterStats myStats; //References NPC Stats
    [SerializeField] FollowWayPoints m_FollowWaypoints;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public override bool Interact()
    {
        base.Interact();
        m_FollowWaypoints.chase = true;
        return true;
    }
}
   
