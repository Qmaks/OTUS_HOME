using System;
using Declarative;
using Lessons.StateMachines;
using Lessons.StateMachines.States;
using UnityEngine.Serialization;

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
        public ShootState shootState;

        [Construct]
        public void Construct(HeroModel root)
        {
            root.onStart += () => 
                this.stateMachine.Enter();
            
            var shootSection = root.core.shootSection;
            var moveSection = root.core.moveSection;

            idleState.Construct(
                shootSection.nearestZombieSensor
                );

            moveState.Construct(
                moveSection.movementDirection,
                moveSection.moveInDirectionEngine,
                moveSection.rotateInDirectionEngine,
                shootSection.nearestZombieSensor);
            
            shootState.Construct(
                moveSection.transform,
                root.core.shootSection.TryShoot,
                root.core.shootSection.nearestZombieSensor,
                moveSection.rotateInDirectionEngine
                );
            
            stateMachine.Construct(
                (CharacterStateType.Idle, idleState),
                (CharacterStateType.Run, moveState),
                (CharacterStateType.Dead, deadState),
                (CharacterStateType.Shoot, shootState)
            );
        }

        [Construct]
        public void ConstructTransitions(LifeSection life, MoveSection moveSection, ShootSection shootSection)
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

            shootSection.nearestZombieSensor.Target.OnChanged += (zombie) =>
            {
                //Если сенсором найдена цель начинаем стрельбу
                if ((zombie!=null)&&(!life.isDeath.Value) && (stateMachine.CurrentState == CharacterStateType.Idle))
                {
                    stateMachine.SwitchState(CharacterStateType.Shoot);
                }
                
                //Если цели закончились возвращаемся в idle
                if ((zombie==null)&&(stateMachine.CurrentState == CharacterStateType.Shoot)&&(!life.isDeath.Value))
                {
                    stateMachine.SwitchState(CharacterStateType.Idle);
                }
            };
        }
    }
}