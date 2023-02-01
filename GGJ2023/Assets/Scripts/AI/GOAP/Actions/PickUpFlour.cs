using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlour : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; //seconds 
    public int carryCapacity = 5;
    public Inventory windmill;

    public PickUpFlour()
    {
        //Requirement for actions + debug name
        addPrecondition("hasStock", true);
        addPrecondition("hasFlour", false); 
        addEffect("hasFlour", true);
        name = "Pickup Flour";
    }
    public override bool checkProceduralPrecondition(GameObject agent)
    {
        return true;
    }

    public override bool isDone()
    {
        return completed;
    }

    public override bool perform(GameObject agent)
    {
        if (startTime == 0)
        {
            Debug.Log("Starting:" + name);
            startTime = Time.time;
        }
        if (Time.time - startTime > workDuration)
        {
            Debug.Log("Finished:" + name);
            this.GetComponent<Inventory>().flourLevel += carryCapacity;
            windmill.flourLevel -= carryCapacity;
            completed = true;
        }
        return true;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override void reset()
    {
        completed = false;
        startTime = 0;
    }
}
