using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverBread : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; //seconds 
    public int deliverySize = 5;

    public DeliverBread()
    {
        //Requirement for actions + debug name
        addPrecondition("hasDelivery", true);
        addEffect("doJob", true);
        name = "DeliverBread";
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
            this.GetComponent<Inventory>().breadLevel -= deliverySize;
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
