using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic.Mechanics;
using Lessons.Gameplay;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public sealed class MoveState : IState
    {
        private MovementDirectionVariable _movementDirection;
        private MoveInDirectionMechanic _moveInDirectionEngine;
        private RotateInDirectionMechanic _rotateInDirectionEngine;
        
        public void Construct(MovementDirectionVariable movementDirection, MoveInDirectionMechanic moveInDirectionEngine,
            RotateInDirectionMechanic rotateInDirectionEngine)
        {
            _movementDirection = movementDirection;
            _moveInDirectionEngine = moveInDirectionEngine;
            _rotateInDirectionEngine = rotateInDirectionEngine;
        }
        
        void IState.Enter()
        {
            _movementDirection.OnChanged += SetDirection;
            SetDirection(_movementDirection);
        }

        void IState.Exit()
        {
            _movementDirection.OnChanged -= SetDirection;
            SetDirection(Vector3.zero);
        }

        private void SetDirection(Vector3 direction)
        {
            _moveInDirectionEngine.SetDirection(direction);
            _rotateInDirectionEngine.SetDirection(direction);
        }
    }
}