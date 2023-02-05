using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimatedPersonData : AnimatedCharacterData
    {
        public Dictionary<FaceState, List<Sprite>> face;
        
        public enum FaceState
        {
            Netural,
            Happy,
            Angry,
            Scared
        }

        public Dictionary<ArmState, List<Sprite>> arms;

        public enum ArmState
        {
            Rest,
            Raised,
            Lasso
        }
    }
}
