using System;
using Homeworks_5.Shooter.Scripts.Atomic.Mechanics;
using Homeworks_5.Shooter.Scripts.Component;
using Homeworks_6.Shooter.Scripts.Atomic.Mechanics;
using Lessons.Gameplay;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class ShootState : IState
    {
        private RotateInDirectionMechanic rotateInDirectionMechanic;
        private NearestTargetSensor<ZombieEntity> nearestTargetSensor;

        private LateUpdateMechanics lateUpdateMechanics = new();
        private Transform transform;
        private AtomicEvent tryShoot;

        public void Construct(Transform transform,
            AtomicEvent tryShoot,
            NearestTargetSensor<ZombieEntity> nearestTargetSensor,
            RotateInDirectionMechanic rotateInDirectionMechanic)
        {
            this.tryShoot = tryShoot;
            this.transform = transform;
            this.nearestTargetSensor = nearestTargetSensor;
            this.rotateInDirectionMechanic = rotateInDirectionMechanic;
        }
        
        public void Enter()
        {
            nearestTargetSensor.Active = true;
            
            lateUpdateMechanics.SetAction((deltaTime =>
            {
                var targetZombie = nearestTargetSensor.Target.Value;
                if (targetZombie != null)
                {
                    tryShoot?.Invoke();
                    var targetPosition = targetZombie.Get<IPositionComponent>().Position;
                    rotateInDirectionMechanic.SetDirection((targetPosition - transform.position).normalized);
                }
            }));
        }

        public void Exit()
        {
            nearestTargetSensor.Active = false;
            lateUpdateMechanics.ClearAction();
        }
    }
}