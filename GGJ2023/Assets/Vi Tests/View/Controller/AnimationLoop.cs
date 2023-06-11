using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimationLoop : MonoBehaviour
    {
        [SerializeField] float m_FramesPerSecond = 3f;
        [SerializeField] int m_frame;
        [SerializeField] float m_rate;
        public event Action<int> OnUpdate;
        IEnumerator m_ActiveLoop;

        bool m_AnimationPlaying = true;

        void OnEnable()
        {
            if (m_ActiveLoop != null)
                StopCoroutine(m_ActiveLoop);
            m_ActiveLoop = AnimationCoroutine();
            StartCoroutine(m_ActiveLoop);
        }

        void OnDisable()
        {
            if (m_ActiveLoop != null)
                StopCoroutine(m_ActiveLoop);
            m_ActiveLoop = null;
        }

        IEnumerator AnimationCoroutine()
        {
            m_rate = 1f / m_FramesPerSecond;
            while (m_AnimationPlaying)
            {
                m_frame++;
                OnUpdate?.Invoke(m_frame);
                yield return new WaitForSeconds(m_rate);
            }

            m_ActiveLoop = null;
        }
    }
}