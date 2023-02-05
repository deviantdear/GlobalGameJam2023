using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimatedPersonController : AnimatedCharacterController
    {
        [SerializeField] AnimatedPersonData m_PersonData;
        [SerializeField] SpriteRenderer m_FaceRenderer;
        [SerializeField] SpriteRenderer m_ArmRenderer;

        AnimatedPersonData.FaceState m_FaceState;
        AnimatedPersonData.ArmState m_ArmState;
        
        internal override AnimatedCharacterData Data { get => m_PersonData; set => m_PersonData = (AnimatedPersonData)value; }

        internal override void UpdateRenderers(int frame)
        {
            base.UpdateRenderers(frame);
            var faceStateAnimated = m_PersonData.face[m_FaceState];
            m_FaceRenderer.sprite = faceStateAnimated[(int)(frame % faceStateAnimated.Count)];
            m_FaceRenderer.flipX = (m_ReverseFlip)?  m_Direction.x < 0 : m_Direction.x > 0;
            var armStateAnimated = m_PersonData.arms[m_ArmState];
            m_ArmRenderer.sprite = armStateAnimated[(int)(frame % armStateAnimated.Count)];
            m_ArmRenderer.flipX = (m_ReverseFlip)?  m_Direction.x < 0 : m_Direction.x > 0;
        }
        
        
        public void SetFaceState(AnimatedPersonData.FaceState faceState)
        {
            m_FaceState = faceState;
            UpdateRenderers(m_Frame);
        }

        void SetArmState(AnimatedPersonData.ArmState armState)
        {
            m_ArmState = armState;
            UpdateRenderers(m_Frame);
        }
    }
}