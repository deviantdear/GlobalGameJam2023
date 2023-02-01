using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;

    public Vector2 maxPos;
    public Vector2 minPos;

    private void FixedUpdate()
    {
        if(transform.position != player.position)
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y, transform.position.z);

            playerPos.x = Mathf.Clamp(playerPos.x, minPos.x, maxPos.x);
            playerPos.y = Mathf.Clamp(playerPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, playerPos, smoothing);
        }
    }
}