using System;
using Declarative;
using Homeworks_5.Shooter.Scripts;
using Homeworks_5.Shooter.Scripts.Zombie;
using Homeworks_6.Shooter.Scripts.Zombie.States;
using Lessons.StateMachines;
using Lessons.StateMachines.States;
using IdleState = Homeworks_6.Shooter.Scripts.Zombie.States.IdleState;
using MoveState = Homeworks_6.Shooter.Scripts.Zombie.States.MoveState;

namespace Homeworks_6.Shooter.Scripts.Zombie
{
    [Serializable]
    public class ZombieStates
    {
        public StateMachine<CharacterStateType> stateMachine;
        
        [Section] public IdleState idleState;

        [Section] public MoveState moveState;

        [Section] public AttackState attackState;
        
        [Section] public DeathState deathState;

        [Construct]
        public void Construct(ZombieModel root)
        {
            root.onStart += () =>
                this.stateMachine.Enter();
            
            var moveSection = root.core.moveSection;
            
            moveState.Construct(
                moveSection.transform,
                root.core.target,
                moveSection.movementDirection,
                moveSection.movementSpeed,
                moveSection.rotationSpeed
                );
            
            attackState.Construct(
                root.core.damageSection.OnAttack,
                root.core.damageSection.attackTimer
                );
            
            stateMachine.Construct(
                (CharacterStateType.Idle, idleState),
                (CharacterStateType.Run, moveState),
                (CharacterStateType.Dead, deathState),
                (CharacterStateType.Attack, attackState)
            );
        }
        
        [Construct]
        public void ConstructTransitions(ZombieModelCore core,LifeSection life, MoveSection moveSection)
        {
            core.target.OnChanged += (target) =>
            {
                //Если есть цель то начинаем преследовать
                if (target != null)
                {
                    if (!life.isDeath.Value && stateMachine.CurrentState == CharacterStateType.Idle)
                    {
                        stateMachine.SwitchState(CharacterStateType.Run);
                    }
                }
                
                //Если нет цель то переходим в Idle
                if (target == null)
                {
                    if (!life.isDeath.Value)
                    {
                        stateMachine.SwitchState(CharacterStateType.Idle);
                    }
                }
            };
            
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

            core.IsNearTarget.value.OnChanged += (value) =>
            {
                if ((value)&&(!life.isDeath.Value))
                    stateMachine.SwitchState(CharacterStateType.Attack);
                
                if ((!value)&&(!life.isDeath.Value))
                    stateMachine.SwitchState(CharacterStateType.Run);
            };
        }
    }
}