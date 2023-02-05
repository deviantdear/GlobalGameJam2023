using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] MovementController m_MovementController;
    [SerializeField] AnimatedCharacterController m_AnimatedCharacterController;
    [SerializeField] SoundEffects m_SoundEffectsController;

    [SerializeField] string m_HorizontalInputAxis;
    [SerializeField] string m_VerticalInputAxis;
    [SerializeField] string m_MooInput;
    [SerializeField] string m_CowbellInput;
    [SerializeField] string m_ActionInput;

    [SerializeField] float m_Fullness = 1f;
    [SerializeField] float m_HungerPerSec = 0.01f;
    [SerializeField] int m_Points;

    [SerializeField] float m_FullSpeed = 3;
    [SerializeField] float m_HungrySpeed = 1;
    public bool Hungry => m_Fullness < 0.0001f;
    public float Fullness => m_Fullness;

    [SerializeField] Collider2D m_InteractionCollider;

    void Update()
    {
        var direction = new Vector2()
        {
            x = Input.GetAxisRaw(m_HorizontalInputAxis),
            y = Input.GetAxisRaw(m_VerticalInputAxis)
        };
        m_MovementController.SetSpeed((Hungry)? m_HungrySpeed : m_FullSpeed);
        m_MovementController.Move(direction);
        m_AnimatedCharacterController.Move(direction);
        
        if (Mathf.Abs(direction.sqrMagnitude) > 0.01) m_SoundEffectsController.Stomp();

        if (Input.GetButtonUp(m_ActionInput))
        {
            // Do action
            InteractNearbyObjects();
        }

        if (Input.GetButton(m_MooInput))
        {
            // Currently mooing
            m_SoundEffectsController.Moo();
        }

        if (Input.GetButton(m_CowbellInput))
        {
            // Currently clanking cowbell
            m_SoundEffectsController.Cowbell();
        }

        m_Fullness -= (m_HungerPerSec * Time.deltaTime);
        if (m_Fullness < 0f) m_Fullness = 0f;
    }

    void InteractNearbyObjects()
    {
        Debug.Log("Interacting nearby");
        var results = new List < Collider2D >();
        var filter = new ContactFilter2D();
        filter.NoFilter();
        var items = m_InteractionCollider.OverlapCollider(filter, results);
        foreach (var item in results)
        {
            var interactable = item.GetComponent<Interactable>();
            if (interactable)
            {
                if (interactable.Interact())
                {
                    m_Fullness += 0.1f;
                    if (m_Fullness > 1f) m_Fullness = 1f;
                }
            }
        }
    }
}
