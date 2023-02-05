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
        
        internal AnimatedCharacterData Data { get => m_Data; set => m_Data = value; }

        public void Move(Vector2 direction)
        {
            
        }
    }
}