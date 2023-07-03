using System;
using Declarative;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class HeroModel_Core
    {
        [Section]
        [SerializeField]
        public WeaponSection weapon = new();
        
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