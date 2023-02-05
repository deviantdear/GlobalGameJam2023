using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimatedCharacterData : ScriptableObject
    {
        public List<Sprite> baseStanding;
        public List<Sprite> baseWalk;
        public List<Sprite> baseSit;
        public List<Sprite> hat;
        
        public enum BaseState
        {
            Standing,
            Walking,
            Sitting
        }
    }
}