using System;
using Declarative;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Bullet.Core
{
    [Serializable]
    public class LookDirection
    {
        [SerializeField]
        public Transform lookTransform;
        
        [SerializeField] 
        public AtomicVariable<Vector3> lookDirection = new();

        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct()
        {
            fixedUpdate.Do(deltaTime =>
            {
                lookTransform.rotation = Quaternion.LookRotation(lookDirection.Value, Vector3.up);
            });
        }
    }
}