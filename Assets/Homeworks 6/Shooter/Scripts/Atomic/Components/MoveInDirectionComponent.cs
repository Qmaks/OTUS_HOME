using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Component
{
    public interface IMoveInDirectionComponent
    {
        void Move(Vector3 direction);
    }

    public sealed class MoveInDirectionComponent : IMoveInDirectionComponent
    {
        private readonly MovementDirectionVariable movementDirection;

        public MoveInDirectionComponent(MovementDirectionVariable movementDirection)
        {
            this.movementDirection = movementDirection;
        }

        public void Move(Vector3 direction)
        {
            movementDirection.Value = direction;
        }
    }
}