using System;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Component;
using Lessons.Gameplay;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_6.Shooter.Scripts.Zombie.States
{
    [Serializable]
    public sealed class MoveState : UpdateState
    {
        private MovementDirectionVariable _movementDirection;
        private AtomicVariable<float> _moveSpeed;
        private AtomicVariable<float> _rotateSpeed;
        private AtomicVariable<Entity> _target;
        private Transform _transform;
        
        private LateUpdateMechanics lateUpdateMechanics = new();

        public void Construct(
            Transform transform,
            AtomicVariable<Entity> target,
            MovementDirectionVariable movementDirection,
            AtomicVariable<float> moveSpeed,
            AtomicVariable<float> rotateSpeed
            )
        {
            _transform = transform;
            _target = target;
            _movementDirection = movementDirection;
            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            var targetPosition =_target.Value.Get<IPositionComponent>().Position;
            _movementDirection.Value = (targetPosition - _transform.position).normalized;
            
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