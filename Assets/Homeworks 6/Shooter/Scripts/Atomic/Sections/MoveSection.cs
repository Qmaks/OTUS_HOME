using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic.Mechanics;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public sealed class MoveSection
    {
        public Transform transform;

        public AtomicVariable<float> movementSpeed = new(6f);
        public AtomicVariable<float> rotationSpeed = new(10f);
        public MovementDirectionVariable movementDirection;

        public MoveInDirectionMechanic moveInDirectionEngine;
        public RotateInDirectionMechanic rotateInDirectionEngine;

        [Construct]
        public void Construct()
        {
            moveInDirectionEngine.Construct(transform, movementSpeed);
            rotateInDirectionEngine.Construct(transform, rotationSpeed);
        }
    }
}