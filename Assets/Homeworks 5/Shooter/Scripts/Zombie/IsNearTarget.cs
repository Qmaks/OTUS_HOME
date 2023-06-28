using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Component;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class IsNearTarget : IFixedUpdateListener
    {
        public AtomicVariable<bool> value = new();
        
        public Transform myTransform;
        public AtomicVariable<Entity> target;

        private const float DELTA = 2f;

        [Construct]
        void Construct(ZombieModelCore core)
        {
            target = core.target;
        }
        
        public void FixedUpdate(float deltaTime)
        {
            var targetPos = target.Value.Get<IGetPositionComponent>().Position;
            if ((targetPos - myTransform.position).magnitude < DELTA)
            {
                value.Value = true;
            }
            else
            {
                value.Value = false;
            }
        }
    }
}