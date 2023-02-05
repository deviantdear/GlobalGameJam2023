using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimationLoop : MonoBehaviour
    {
        [SerializeField] float m_FramesPerSecond = 3;
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
            while (m_AnimationPlaying)
            {
                var time = Time.time;
                var frame = (int)(time * m_FramesPerSecond);
                OnUpdate?.Invoke(frame);
                yield return new WaitForSeconds(m_FramesPerSecond);
            }

            m_ActiveLoop = null;
        }
    }
}