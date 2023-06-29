using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class MeleeDamageSection
    {
        [SerializeField] 
        public MonoBehaviour coroutineRunner;
        
        [FormerlySerializedAs("delay")] [SerializeField]
        public TimerMechanics attackTimer;

        public AtomicVariable<int> damage;

        public AtomicEvent OnAttack;

        [Construct]
        public void Construct()
        {
            OnAttack += () =>
            {
                if (!attackTimer.IsPlaying)
                {
                    coroutineRunner.StartCoroutine(attackTimer.Play());
                }
            };
        }
    }
}