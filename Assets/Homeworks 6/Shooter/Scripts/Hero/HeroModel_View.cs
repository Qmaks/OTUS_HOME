using System;
using Declarative;
using Lessons.Gameplay;
using Lessons.StateMachines;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class HeroModel_View
    {
        public AnimatorStateMachine<AnimatorStateType> animatorMachine;
        
        [SerializeField]
        public AtomicVariable<Transform> shootingPoint = new();
        
        [Construct]
        public void ConstructStates()
        {
            // this.animatorMachine.Construct(
            //     (AnimatorStateType.Idle, null),
            //     (AnimatorStateType.Run, null),
            //     (AnimatorStateType.Dead, null),
            //     (AnimatorStateType.Shoot, null)
            // );
        }
        
        [Construct]
        public void ConstructTransitions(HeroStates states)
        {
            var coreFSM = states.stateMachine;

            this.animatorMachine.AddTransition(AnimatorStateType.Idle, () =>
                coreFSM.CurrentState == CharacterStateType.Idle);

            this.animatorMachine.AddTransition(AnimatorStateType.Run,
                () => coreFSM.CurrentState == CharacterStateType.Run);

            this.animatorMachine.AddTransition(AnimatorStateType.Shoot,
                () => coreFSM.CurrentState == CharacterStateType.Shoot);
            
            this.animatorMachine.AddTransition(AnimatorStateType.Dead,
                () => coreFSM.CurrentState == CharacterStateType.Dead);
        }


    }
}