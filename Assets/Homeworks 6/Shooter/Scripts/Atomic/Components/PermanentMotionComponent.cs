using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Bullet.Components
{
    public interface IPermanentMotionComponent
    {
        void Direction(Vector3 direction);
    }
    
    public class PermanentMotionComponent : IPermanentMotionComponent
    {
        private readonly IAtomicVariable<Vector3> direction;

        public PermanentMotionComponent(IAtomicVariable<Vector3> direction)
        {
            this.direction = direction;
        }

        public void Direction(Vector3 direction)
        {
            this.direction.Value = direction;
        }
    }
}
