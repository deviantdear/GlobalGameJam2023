using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimatedRideableController : AnimatedCharacterController
    {
        [SerializeField] AnimatedRideableData m_Data;
        [SerializeField] Transform m_RideablePoint;
        
        internal override AnimatedCharacterData Data { get => m_Data; set => m_Data = (AnimatedRideableData)value; }
    }
}