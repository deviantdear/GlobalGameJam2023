using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] MovementController m_MovementController;
    [SerializeField] AnimatedCharacterController m_AnimatedCharacterController;

    [SerializeField] string m_HorizontalInputAxis;
    [SerializeField] string m_VerticalInputAxis;
    [SerializeField] string m_MooInput;
    [SerializeField] string m_CowbellInput;
    [SerializeField] string m_ActionInput;

    [SerializeField] float m_Fullness = 1f;
    [SerializeField] float m_HungerPerSec = 0.01f;
    [SerializeField] int m_Points;

    void Update()
    {
        var direction = new Vector2()
        {
            x = Input.GetAxisRaw(m_HorizontalInputAxis),
            y = Input.GetAxisRaw(m_VerticalInputAxis)
        };
        
        m_MovementController.Move(direction);
        m_AnimatedCharacterController.Move(direction);

        if (Input.GetButtonUp(m_ActionInput))
        {
            // Do action
        }

        if (Input.GetButton(m_MooInput))
        {
            // Currently mooing
        }

        if (Input.GetButton(m_CowbellInput))
        {
            // Currently clanking cowbell
        }

        m_Fullness -= (m_HungerPerSec * Time.deltaTime);
    }
}
