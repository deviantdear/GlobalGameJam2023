using UnityEngine;

namespace Character
{
    public class AnimatedPersonData : AnimatedCharacterData
    {
        public Sprite m_FaceNetural;
        public Sprite m_FaceHappy;
        public Sprite m_FaceAngry;
        public Sprite m_FaceScared;
        
        public enum FaceState
        {
            Netural,
            Happy,
            Angry,
            Scared
        }

        public Sprite m_ArmsRestingRest;
        public Sprite m_ArmsRestingA;
        public Sprite m_ArmsRestingB;
        public Sprite m_ArmsRaisedRest;
        public Sprite m_ArmsRaisedA;
        public Sprite m_ArmsRaisedB;
        public Sprite m_ArmsLassoRest;
        public Sprite m_ArmsLassoA;
        public Sprite m_ArmsLassoB;
        
        public enum ArmState
        {
            Rest,
            Raised,
            Lasso
        }
    }
}
