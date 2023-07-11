using System;
using Homeworks_5.Shooter.Scripts.Component;
using Homeworks_6.Shooter.Scripts.Atomic.Mechanics;
using Lessons.Gameplay;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class ShootState : UpdateState
    {
        private AtomicVariable<float> rotateSpeed;
        private NearestTargetSensor<ZombieEntity> nearestTargetSensor;

        private Transform transform;
        private AtomicEvent tryShoot;

        public void Construct(
            Transform transform,
            AtomicEvent tryShoot,
            NearestTargetSensor<ZombieEntity> nearestTargetSensor,
            AtomicVariable<float> rotateSpeed
            )
        {
            this.tryShoot = tryShoot;
            this.transform = transform;
            this.nearestTargetSensor = nearestTargetSensor;
            this.rotateSpeed = rotateSpeed;
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            nearestTargetSensor.Active = true;
        }

        protected override void OnExit()
        {
            base.OnExit();
            nearestTargetSensor.Active = false;
        }

        protected override void OnUpdate(float deltaTime)
        {
            var targetZombie = nearestTargetSensor.Target.Value;
            
            if (targetZombie != null)
            {
                var targetPosition = targetZombie.Get<IPositionComponent>().Position;
                var targetDirection = (targetPosition - transform.position).normalized;
                
                if (targetDirection == Vector3.zero)
                {
                    return;
                }

                var currentRotation = transform.rotation;
                var targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotateSpeed.Value * deltaTime);

                if (Vector3.Angle(transform.forward, targetDirection) < 5)
                {
                    tryShoot?.Invoke();
                }
            }
        }
    }
}