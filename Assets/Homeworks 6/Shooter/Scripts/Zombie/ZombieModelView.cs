using System;
using Declarative;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public sealed class ZombieModelView
    {
        private static readonly int State = Animator.StringToHash("State");
        private const int IDLE_STATE = 0;
        private const int MOVE_STATE = 1;
        private const int ATTACK_STATE = 3;

        [SerializeField]
        public Animator animator;
        
        [Construct]
        public void Construct(ZombieModelCore core)
        {
            core.damageSection.attackTimer.OnStartPlay += () =>
            {
                animator.SetInteger(State, ATTACK_STATE);
            };
            
            core.IsNearTarget.value.OnChanged += (value) =>
            {
                if ((value)&&(!core.damageSection.attackTimer.IsPlaying))
                {
                    animator.SetInteger(State, IDLE_STATE);
                }
                
                if ((!value)&&(!core.damageSection.attackTimer.IsPlaying))
                {
                    animator.SetInteger(State, MOVE_STATE);
                }
            };
        }
    }
}