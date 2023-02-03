using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

// A very simplistic movement script on the x-z plane.

namespace ValTestScripts
{

    public class Move : MonoBehaviour
    {
        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;
        public GameObject obstacle;

        void Start()
        {

        }

        void LateUpdate()
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            // Move translation along the object's x-axis
            transform.Translate( 0, translation, 0);

            // Rotate around our y-axis
            transform.Rotate(0, 0, -rotation);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CalculateDistance();
                CalculateAngle();
            }

        }

        private void CalculateDistance()
        {
           float distance = (float)Math.Sqrt(Mathf.Pow(obstacle.transform.position.x - transform.position.x, 2) + Mathf.Pow(obstacle.transform.position.y - transform.position.y, 2));

           float uDistance = Vector3.Distance(obstacle.transform.position, transform.position);

            Debug.Log("Distance: " + distance);
            Debug.Log("UDistance: " + uDistance);
        }

        private void CalculateAngle()
        {



        }
    }
}