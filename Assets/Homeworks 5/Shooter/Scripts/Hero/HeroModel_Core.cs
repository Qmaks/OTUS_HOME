using System;
using Declarative;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class HeroModel_Core
    {
        [Section]
        [SerializeField]
        public Weapon weapon = new();
        
        [Section]
        [SerializeField]
        public Life life = new();

        [Section]
        [SerializeField]
        public Move move = new();
        
        [FormerlySerializedAs("look")]
        [Section]
        [SerializeField]
        public LookAt lookAt = new();
    }
}