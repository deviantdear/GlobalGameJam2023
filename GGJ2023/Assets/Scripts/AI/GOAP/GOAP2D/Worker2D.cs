using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker2D : MonoBehaviour, IGoap
{
    public NPCHuman npc;
    Vector2 previousDestination;
    private CharacterStats npcStats;
    public CharacterStats player;
    public Transform[] waypoints;
    int currentWp = 0;
    public float speed = 10.0f;
    public bool chase = false;
    public Transform cow;

    public static Action Chase;

    void Update()
    {
        //endless loop
        if (!chase)
        {
            //Autofollow();
        }
        if (chase)
        {
            Chase?.Invoke();
            transform.position = Vector2.MoveTowards(transform.position, cow.transform.position, speed * Time.deltaTime);
        }

    }

    public void ActionsFinished()
    {
        throw new System.NotImplementedException();
    }

    public HashSet<KeyValuePair<string, object>> CreateGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
        //Global Goal
        goal.Add(new KeyValuePair<string, object>("doJob", true));
        return goal;
    }

    public HashSet<KeyValuePair<string, object>> GetWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
        worldData.Add(new KeyValuePair<string, object>("Chasing", chase));
        worldData.Add(new KeyValuePair<string, object>("Idle", !chase));
        return worldData;
    }

    public bool MoveAgent(GoapAction nextAction)
    {
        //if we don't need to move anywhere
        if ((transform.position == waypoints[currentWp].transform.position))
        {
            currentWp += 1;
            nextAction.setInRange(true);
            return true;
        }

        //We have reached our destination -> next action
        if (currentWp == waypoints.Length)
        {
            currentWp = 0;
            nextAction.setInRange(true);
            previousDestination = nextAction.target.transform.position;
            return true;
        }
        else
            return false;
    }

    public void PlanAborted(GoapAction aborter)
    {
        throw new System.NotImplementedException();
    }

    public void PlanFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        throw new System.NotImplementedException();
    }

    public void PlanFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
    {
        throw new System.NotImplementedException();
    }
}
