using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Component;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class IsNearTargetMechanics : IFixedUpdateListener
    {
        public AtomicVariable<bool> value = new();
        
        public Transform myTransform;
        public AtomicVariable<Entity> target;

        private const float DELTA = 2f;

        public void Construct(Transform transform,AtomicVariable<Entity> target)
        {
            this.myTransform = transform;
            this.target = target;
        }
        
        public void FixedUpdate(float deltaTime)
        {
            var targetPos = target.Value.Get<IPositionComponent>().Position;
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