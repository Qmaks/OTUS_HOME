using System;
using Declarative;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class HeroModel_Core
    {
        [FormerlySerializedAs("weapon")]
        [Section]
        [SerializeField]
        public ShootSection shootSection = new();
        
        [Section]
        [SerializeField]
        public LifeSection lifeSection = new();

        [Section]
        [SerializeField]
        public MoveSection moveSection = new();

        [Section]
        [SerializeField]
        public HeroStates states;
    }
}