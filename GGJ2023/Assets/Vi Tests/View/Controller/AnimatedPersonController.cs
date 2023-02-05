using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimatedPersonController : AnimatedCharacterController
    {
        [SerializeField] AnimatedPersonData m_Data;
        [SerializeField] SpriteRenderer m_FaceRenderer;
        [SerializeField] SpriteRenderer m_ArmRenderer;
        
        internal AnimatedCharacterData Data { get => m_Data; set => m_Data = (AnimatedPersonData)value; }

        void SetFaceState(AnimatedPersonData.FaceState faceState)
        {
            switch (faceState)
            {
                
            }
        }

        void SetArmState(AnimatedPersonData.ArmState armState)
        {
            switch (armState)
            {
                
            }
        }
    }
}