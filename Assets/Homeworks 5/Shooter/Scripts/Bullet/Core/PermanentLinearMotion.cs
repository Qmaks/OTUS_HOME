using System;
using Declarative;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Bullet
{
    [Serializable]
    public class PermanentLinearMotion
    {
        [SerializeField]
        public Transform moveTransform;

        [SerializeField]
        public AtomicVariable<Vector3> moveDirection = new();
        
        [SerializeField]
        public AtomicVariable<float> speed = new();

        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct()
        {
            fixedUpdate.Do(deltaTime =>
            {
                moveTransform.position += moveDirection.Value * (speed.Value * deltaTime);
            });
        }
    }
}