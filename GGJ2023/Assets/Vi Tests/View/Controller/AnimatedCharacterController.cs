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
        [SerializeField] bool m_ReverseFlip;
        
        internal AnimatedCharacterData Data { get => m_Data; set => m_Data = value; }
        internal Vector2 m_Direction;
        internal AnimatedCharacterData.BaseState m_BaseState;

        public void Move(Vector2 direction)
        {
            m_Direction = direction;
        }

        public void SetState(AnimatedCharacterData.BaseState state)
        {
            m_BaseState = state;
        }

        internal virtual void UpdateRenderers()
        {
            var time = Time.time;
            switch (m_BaseState)
            {
                case AnimatedCharacterData.BaseState.Sitting:
                    m_BaseRenderer.sprite =
                        m_Data.baseSit[(int)((time * m_Data.framesPerSecond) % m_Data.baseSit.Count)];
                    break;
                case AnimatedCharacterData.BaseState.Standing:
                    m_BaseRenderer.sprite =
                        m_Data.baseStanding[(int)((time * m_Data.framesPerSecond) % m_Data.baseStanding.Count)];
                    break;
                case AnimatedCharacterData.BaseState.Walking:
                    m_BaseRenderer.sprite =
                        m_Data.baseWalk[(int)((time * m_Data.framesPerSecond) % m_Data.baseWalk.Count)];
                    break;
            }

            m_BaseRenderer.flipX = (m_ReverseFlip)?  m_Direction.x < 0 : m_Direction.x > 0;
        }

        IEnumerable AnimationUpdate()
        {
            while (gameObject.activeSelf)
            {
                UpdateRenderers();
                yield return new WaitForSeconds(m_Data.framesPerSecond);
            }
        }
    }
}