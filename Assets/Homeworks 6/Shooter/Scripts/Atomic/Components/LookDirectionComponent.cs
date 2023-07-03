using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Bullet.Components
{
    public interface ILookDirectionComponent
    {
        void Direction(Vector3 direction);
    }

    public class LookDirectionComponent : ILookDirectionComponent
    {
        private readonly IAtomicVariable<Vector3> direction;

        public LookDirectionComponent(IAtomicVariable<Vector3> direction)
        {
            this.direction = direction;
        }

        public void Direction(Vector3 direction)
        {
            this.direction.Value = direction;
        }
    }
}