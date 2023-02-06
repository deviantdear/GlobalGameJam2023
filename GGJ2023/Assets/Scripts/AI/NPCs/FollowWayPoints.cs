using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField] MovementController m_MovementController;
    [SerializeField] AnimatedPersonController m_AnimatedPersonController;
    [SerializeField] bool m_FearCow = false;
    public Transform[] waypoints;
    int currentWp = 0;
    public float speed = 10.0f;
    public bool chase = false;
    public Transform cow;

    public static Action Chase;

    Vector2 m_MovementDirection;

    private void Start()
    {
        transform.position = waypoints[currentWp].transform.position;
        cow = FindObjectOfType<PlayerController>()?.transform;
    }

    private void Update()
    {
        //endless loop
        if (!chase)
        {
            m_AnimatedPersonController.SetArmState(AnimatedPersonData.ArmState.Rest);
            m_AnimatedPersonController.SetFaceState(AnimatedPersonData.FaceState.Netural);
            Autofollow();
        }
        if (chase && cow)
        {
            Chase?.Invoke();
            if (!m_FearCow)
            {
                
                m_AnimatedPersonController.SetArmState(AnimatedPersonData.ArmState.Lasso);
                m_AnimatedPersonController.SetFaceState(AnimatedPersonData.FaceState.Angry);

                m_MovementDirection = cow.position - transform.position;
            }
            else
            {
                m_AnimatedPersonController.SetArmState(AnimatedPersonData.ArmState.Raised);
                m_AnimatedPersonController.SetFaceState(AnimatedPersonData.FaceState.Scared);

                m_MovementDirection = (cow.position - transform.position ) * -1;
            }
        }
        
        m_MovementController.Move(m_MovementDirection);
        m_AnimatedPersonController.Move(m_MovementDirection);
    }


    public void Autofollow()
    {
        m_MovementDirection = waypoints[currentWp].transform.position - transform.position;

        if(Vector2.Distance(transform.position, waypoints[currentWp].transform.position) < 0.1)
        {
            //increment to next waypoint
            currentWp+= 1;
            Debug.Log($"Next waypoint {currentWp}");
        }
        if(currentWp == waypoints.Length)
        {
            //reset waypoint
            currentWp = 0;
        }
    }
}
