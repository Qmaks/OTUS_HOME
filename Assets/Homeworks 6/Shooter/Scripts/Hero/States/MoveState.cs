using System;
using Lessons.Gameplay;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public sealed class MoveState : UpdateState
    {
        private MovementDirectionVariable _movementDirection;
        private AtomicVariable<float> _moveSpeed;
        private AtomicVariable<float> _rotateSpeed;
        private Transform _transform;

        public void Construct(
            MovementDirectionVariable movementDirection,
            Transform transform,
            AtomicVariable<float> moveSpeed,
            AtomicVariable<float> rotateSpeed
            )
        {
            _transform = transform;
            _rotateSpeed = rotateSpeed;
            _moveSpeed = moveSpeed;
            _movementDirection = movementDirection;
        }

        protected override void OnUpdate(float deltaTime)
        {
            _transform.position += _movementDirection.Value * (_moveSpeed.Value * deltaTime);
            
            if (_movementDirection.Value == Vector3.zero)
            {
                return;
            }
            
            var currentRotation = _transform.rotation;
            var targetRotation = Quaternion.LookRotation(_movementDirection.Value);
            _transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotateSpeed.Value * deltaTime);

        }
    }
}