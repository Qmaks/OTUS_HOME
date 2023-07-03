using System;
using Declarative;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Atomic.Mechanics
{
    [Serializable]
    public class RotateInDirectionMechanic : IUpdateListener
    {
        private Transform _targetTransform;
        private AtomicVariable<float> _speed;

        private Vector3 _direction;

        public void Construct(Transform targetTransform, AtomicVariable<float> speed)
        {
            _targetTransform = targetTransform;
            _speed = speed;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            if (_direction == Vector3.zero)
            {
                return;
            }

            var currentRotation = _targetTransform.rotation;
            var targetRotation = Quaternion.LookRotation(_direction);
            _targetTransform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _speed.Value * deltaTime);
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}
