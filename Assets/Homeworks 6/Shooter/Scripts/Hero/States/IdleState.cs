using System;
using Homeworks_6.Shooter.Scripts.Atomic.Mechanics;
using UnityEngine;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class IdleState : IState
    {
        private NearestTargetSensor<ZombieEntity> nearestTargetSensor;
        private Transform transform;

        public void Construct(NearestTargetSensor<ZombieEntity> nearestTargetSensor)
        {
            this.nearestTargetSensor = nearestTargetSensor;
        }
        
        public void Enter()
        {
            nearestTargetSensor.Active = true;
        }

        public void Exit()
        {
        }
    }
}