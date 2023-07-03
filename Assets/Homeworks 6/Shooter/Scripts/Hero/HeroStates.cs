using System;
using Declarative;
using Lessons.StateMachines;
using Lessons.StateMachines.States;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class HeroStates 
    {
        public StateMachine<CharacterStateType> stateMachine;
        
        [Section]
        public IdleState idleState;

        [Section]
        public MoveState moveState;

        [Section]
        public DeadState deadState;
        
        [Section]
        public ShootState shotState;

        [Construct]
        public void Construct(HeroModel root,MoveSection moveSection)
        {
            root.onStart += () => 
                this.stateMachine.Enter();
            
            moveState.Construct(moveSection.movementDirection,
                moveSection.moveInDirectionEngine,
                moveSection.rotateInDirectionEngine);
            
            stateMachine.Construct(
                (CharacterStateType.Idle, idleState),
                (CharacterStateType.Run, moveState),
                (CharacterStateType.Dead, deadState)
            );
        }
        
        [Construct]
        public void ConstructTransitions(LifeSection life,MoveSection moveSection)
        {
            life.isDeath.OnChanged += isDeath =>
            {
                var stateType = isDeath ? CharacterStateType.Dead : CharacterStateType.Idle;
                stateMachine.SwitchState(stateType);
            };

            moveSection.movementDirection.MovementStarted += () =>
            {
                if (!life.isDeath.Value)
                {
                    stateMachine.SwitchState(CharacterStateType.Run);
                }
            };

            moveSection.movementDirection.MovementFinished += () =>
            {
                if (!life.isDeath.Value && stateMachine.CurrentState == CharacterStateType.Run)
                {
                    stateMachine.SwitchState(CharacterStateType.Idle);
                }
            };
        }
    }
}