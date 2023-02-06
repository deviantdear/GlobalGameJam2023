using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class AnimatedRideableController : AnimatedCharacterController
    {
        [SerializeField] AnimatedRideableData m_RideableData;
        [SerializeField] Transform m_RideablePoint;
        
        internal override AnimatedCharacterData Data { get => m_RideableData; set => m_RideableData = (AnimatedRideableData)value; }
    }
}