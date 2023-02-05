using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_RigidBody;
    [SerializeField] float m_Speed;
    [SerializeField] Vector2 m_Direction;

    public void Move(Vector2 direction)
    {
        m_Direction = direction;
        
    }

    public void SetSpeed(float newSpeed) => m_Speed = newSpeed;
    
    void FixedUpdate()
    {
        m_RigidBody.MovePosition(m_RigidBody.position + m_Direction.normalized * m_Speed * Time.fixedDeltaTime);
    }
}
