using System;
using Declarative;
using Lessons.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class MeleeDamageSection
    {
        [FormerlySerializedAs("delay")] [SerializeField]
        public Timer attackTimer;

        public AtomicVariable<int> damage;

        public AtomicEvent OnAttack;

        [Construct]
        public void Construct(ZombieModelCore core)
        {
            OnAttack += () =>
            {
                if (!attackTimer.IsPlaying)
                {
                    core.coroutineRunner.StartCoroutine(attackTimer.Play());
                }
            };
        }
    }
}