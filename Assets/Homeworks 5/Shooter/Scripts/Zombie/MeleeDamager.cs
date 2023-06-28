using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class MeleeDamager
    {
        [SerializeField] 
        public Entity entity;
        
        [FormerlySerializedAs("delay")] [SerializeField]
        public Timer attackTimer;

        public AtomicVariable<int> damage;

        public AtomicEvent OnAttack;

        [Construct]
        public void Construct()
        {
            OnAttack += () =>
            {
                if (!attackTimer.IsPlaying)
                {
                    entity.StartCoroutine(attackTimer.Play());
                }
            };
        }
    }
}