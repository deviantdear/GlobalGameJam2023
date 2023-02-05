using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    
    public class AnimatedCharacterController : MonoBehaviour
    {
        [SerializeField] AnimatedCharacterData m_Data;
        [SerializeField] SpriteRenderer m_BaseRenderer;
        [SerializeField] SpriteRenderer m_HatRenderer;
        [SerializeField] internal bool m_ReverseFlip;
        [SerializeField] AnimationLoop m_AnimationLoop;
        
        internal virtual AnimatedCharacterData Data { get => m_Data; set => m_Data = value; }
        internal Vector2 m_Direction;
        internal AnimatedCharacterData.BaseState m_BaseState = AnimatedCharacterData.BaseState.Standing;

        public void Move(Vector2 direction)
        {
            m_Direction = direction;
            if (Math.Abs(m_Direction.magnitude) > 0.01)
            {
                m_BaseState = AnimatedCharacterData.BaseState.Walking;
            } else if (m_BaseState == AnimatedCharacterData.BaseState.Walking)
                m_BaseState = AnimatedCharacterData.BaseState.Standing;
        }

        public void SetState(AnimatedCharacterData.BaseState state)
        {
            m_BaseState = state;
        }
        
        

        void OnEnable()
        {
            m_AnimationLoop.OnUpdate += UpdateRenderers;
        }

        void OnDisable()
        {
            m_AnimationLoop.OnUpdate -= UpdateRenderers;
        }

        internal virtual void UpdateRenderers(int frame)
        {
            if (!gameObject.activeSelf)
                return;
            var flipx = (m_ReverseFlip)?  m_Direction.x < 0 : m_Direction.x > 0;
            switch (m_BaseState)
            {
                case AnimatedCharacterData.BaseState.Sitting:
                    m_BaseRenderer.sprite =
                        m_Data.baseSit[(int)(frame % m_Data.baseSit.Count)];
                    break;
                case AnimatedCharacterData.BaseState.Standing:
                    m_BaseRenderer.sprite =
                        m_Data.baseStanding[(int)(frame % m_Data.baseStanding.Count)];
                    break;
                case AnimatedCharacterData.BaseState.Walking:
                    m_BaseRenderer.sprite =
                        m_Data.baseWalk[(int)(frame % m_Data.baseWalk.Count)];
                    break;
            }

            m_BaseRenderer.flipX = flipx;
            m_HatRenderer.sprite = m_Data.hat[(int)(frame % m_Data.hat.Count)];
            m_HatRenderer.flipX = flipx;
        }
    }
}