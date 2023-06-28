using System;
using Declarative;
using Lessons.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public sealed class Move
    {
        [SerializeField]
        public Transform moveTransform;

        [ShowInInspector]
        public AtomicEvent<Vector3> onMove = new();

        [SerializeField]
        public AtomicVariable<bool> moveRequired = new();

        [SerializeField]
        public AtomicVariable<Vector3> moveDirection = new();
        
        [SerializeField]
        public AtomicVariable<float> speed = new();

        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct(Life life)
        {
            var isDeath = life.isDeath;
            onMove += direction =>
            {
                if (isDeath.Value)
                {
                    return;
                }

                moveDirection.Value = direction;
                moveRequired.Value = true;
            };

            
            fixedUpdate.Do(deltaTime =>
            {
                if (moveRequired.Value)
                {
                    moveTransform.position += moveDirection.Value * (speed.Value * deltaTime);
                    moveRequired.Value = false;
                }
            });
        }
    }
}