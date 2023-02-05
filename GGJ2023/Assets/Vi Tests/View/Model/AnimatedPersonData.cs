using System;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    
    [CreateAssetMenu(menuName = "Character/AnimatedPersonData")]
    public class AnimatedPersonData : AnimatedCharacterData
    {
        public Dictionary<FaceState, List<Sprite>> face
        {
            get
            {
                return new Dictionary<FaceState, List<Sprite>>()
                {
                    { FaceState.Netural, m_FaceNetrual },
                    { FaceState.Happy, m_FaceHappy },
                    { FaceState.Angry, m_FaceAngry },
                    { FaceState.Scared, m_FaceScared },
                };
            }
        }

        [SerializeField] List<Sprite> m_FaceNetrual;
        [SerializeField] List<Sprite> m_FaceHappy;
        [SerializeField] List<Sprite> m_FaceAngry;
        [SerializeField] List<Sprite> m_FaceScared;
        

        [Serializable]
        public enum FaceState
        {
            Netural,
            Happy,
            Angry,
            Scared
        }

        public Dictionary<ArmState, List<Sprite>> arms
        {
            get
            {
                return new Dictionary<ArmState, List<Sprite>>()
                {
                    { ArmState.Rest, m_ArmsRest },
                    { ArmState.Raised, m_ArmsRaised },
                    { ArmState.Lasso, m_ArmsLasso },
                };
            }
        }
        [SerializeField] List<Sprite> m_ArmsRest;
        [SerializeField] List<Sprite> m_ArmsRaised;
        [SerializeField] List<Sprite> m_ArmsLasso;

        [Serializable]
        public enum ArmState
        {
            Rest,
            Raised,
            Lasso
        }
    }
}
