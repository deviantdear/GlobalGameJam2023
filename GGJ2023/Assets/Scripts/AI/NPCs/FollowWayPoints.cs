using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    public Transform[] waypoints;
    int currentWp = 0;
    public float speed = 10.0f;
    public bool chase = false;
    public Transform cow;

    public static Action Chase;

    private void Start()
    {
        transform.position = waypoints[currentWp].transform.position;
    }

    private void Update()
    {
        //endless loop
        if (!chase)
        {
            Autofollow();
        }
        if (chase)
        {
            Chase?.Invoke();
            transform.position = Vector2.MoveTowards(transform.position, cow.transform.position, speed * Time.deltaTime);
        }
    }


    public void Autofollow()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWp].transform.position, speed * Time.deltaTime);

        if(transform.position == waypoints[currentWp].transform.position)
        {
            //increment to next waypoint
            currentWp+= 1;
        }
        if(currentWp == waypoints.Length)
        {
            //reset waypoint
            currentWp = 0;
        }
    }
}
