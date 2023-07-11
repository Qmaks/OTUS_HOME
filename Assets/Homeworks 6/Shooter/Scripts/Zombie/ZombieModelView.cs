using System;
using Declarative;
using Homeworks_6.Shooter.Scripts.Zombie;
using Lessons.StateMachines;
using Lessons.StateMachines.States;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public sealed class ZombieModelView
    {
        public AnimatorStateMachine<AnimatorStateType> animatorMachine;

        public Transform transform;

        public GameObject deathPuppet;
        
        [Construct]
        public void ConstructFX(ZombieModelCore core)
        {
            core.lifeSection.isDeath.OnChanged += (isDeath) =>
            {
                if (isDeath)
                {
                    Object.Instantiate(deathPuppet, transform.position, transform.rotation);
                }
            };
        }

        [Construct]
        public void ConstructTransitions(ZombieStates states)
        {
            var coreFSM = states.stateMachine;

            this.animatorMachine.AddTransition(AnimatorStateType.Idle, () =>
                coreFSM.CurrentState == CharacterStateType.Idle);

            this.animatorMachine.AddTransition(AnimatorStateType.Run,
                () => coreFSM.CurrentState == CharacterStateType.Run);

            this.animatorMachine.AddTransition(AnimatorStateType.Shoot,
                () => coreFSM.CurrentState == CharacterStateType.Attack);
            
            this.animatorMachine.AddTransition(AnimatorStateType.Dead,
                () => coreFSM.CurrentState == CharacterStateType.Dead);
        }
    }
}