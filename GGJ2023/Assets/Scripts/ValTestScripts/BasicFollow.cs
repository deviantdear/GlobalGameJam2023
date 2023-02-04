using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ValTestScripts
{

    public class BasicFollow : MonoBehaviour
    {
        public GameObject obstacle;
        bool autopilot = false;
        float speed = 2f;
        float rspeed = 0.2f;

        void AutoPilot()
        {
            CalculateAngle();
            this.transform.position += this.transform.up * speed * Time.deltaTime;
        }

        void LateUpdate()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CalculateDistance();
                CalculateAngle();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                autopilot = !autopilot; //toggle
            }

            if(CalculateDistance() < 2)
            {
                autopilot =false;   
            }

            if (autopilot)
            {
                AutoPilot();
            }

        }


        Vector3 Cross(Vector3 v, Vector3 w)
        {
            float xMult = v.y * w.z - v.z * w.y;
            float yMult = v.x * w.z - v.z * w.x;
            float zMult = v.x * w.y - v.y * w.x;

            return (new Vector3(xMult, yMult, zMult));
        }

        private float CalculateDistance()
        {
            float distance = (float)Math.Sqrt(Mathf.Pow(obstacle.transform.position.x - transform.position.x, 2) + Mathf.Pow(obstacle.transform.position.y - transform.position.y, 2));

            float uDistance = Vector3.Distance(obstacle.transform.position, transform.position);

            Debug.Log("Distance: " + distance);
            Debug.Log("UDistance: " + uDistance);

            return distance;
        }

        private void CalculateAngle()
        {

            Vector3 forward = transform.up;
            Vector3 obstacleDirection = obstacle.transform.position - transform.position;

            Debug.DrawRay(this.transform.position, forward, Color.blue);
            Debug.DrawRay(this.transform.position, obstacleDirection, Color.red);

            float dot = forward.x * obstacleDirection.x + forward.y * obstacleDirection.y;
            float angle = Mathf.Acos(dot / (forward.magnitude * obstacleDirection.magnitude));

            Debug.Log("Angle: " + angle * Mathf.Rad2Deg); //Radians to Degrees
            Debug.Log("Unity Angle: " + Vector3.Angle(forward, obstacleDirection)); //Radians to Degrees

            int clockwise = 1;
            if (Cross(forward, obstacleDirection).z < 0)
                clockwise = -1;

            if ((angle * Mathf.Rad2Deg) > 10)
                this.transform.Rotate(0, 0, angle * Mathf.Rad2Deg * clockwise * rspeed);
        }
    }
}