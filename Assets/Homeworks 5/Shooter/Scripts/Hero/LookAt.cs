using System;
using Declarative;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class LookAt
    {
        [SerializeField]
        public Transform lookTransform;
        
        [SerializeField]
        public AtomicVariable<Vector3> lookAt = new();
        
        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct()
        {
            fixedUpdate.Do(deltaTime =>
            {
                lookTransform.LookAt(lookAt.Value);    
            });
        }
    }
}