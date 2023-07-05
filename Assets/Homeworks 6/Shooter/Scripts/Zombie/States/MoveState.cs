using System;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Atomic.Mechanics;
using Homeworks_5.Shooter.Scripts.Component;
using Lessons.Gameplay;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_6.Shooter.Scripts.Zombie.States
{
    [Serializable]
    public sealed class MoveState : IState
    {
        private MovementDirectionVariable _movementDirection;
        private MoveInDirectionMechanic _moveInDirectionEngine;
        private RotateInDirectionMechanic _rotateInDirectionEngine;
        private AtomicVariable<Entity> _target;
        private Transform _transform;
        
        private LateUpdateMechanics lateUpdateMechanics = new();

        public void Construct(
            Transform transform,
            AtomicVariable<Entity> target,
            MovementDirectionVariable movementDirection,
            MoveInDirectionMechanic moveInDirectionEngine,
            RotateInDirectionMechanic rotateInDirectionEngine
            )
        {
            _transform = transform;
            _target = target;
            _movementDirection = movementDirection;
            _moveInDirectionEngine = moveInDirectionEngine;
            _rotateInDirectionEngine = rotateInDirectionEngine;
        }
        
        void IState.Enter()
        {
            _movementDirection.OnChanged += SetDirection;
            SetDirection(_movementDirection);
            
            lateUpdateMechanics.SetAction((deltaTime =>
            {
                var targetPosition =_target.Value.Get<IPositionComponent>().Position;
                _movementDirection.Value = (targetPosition - _transform.position).normalized; 
            } ));
        }

        void IState.Exit()
        {
            _movementDirection.OnChanged -= SetDirection;
            lateUpdateMechanics.ClearAction();
            SetDirection(Vector3.zero);
        }

        private void SetDirection(Vector3 direction)
        {
            _moveInDirectionEngine.SetDirection(direction);
            _rotateInDirectionEngine.SetDirection(direction);
        }
    }
}