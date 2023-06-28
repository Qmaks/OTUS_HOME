using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;

namespace Homeworks_5.Shooter.Scripts.Zombie.Component
{
    public interface ITargetComponent
    {
        void SetTarget(Entity target);
    }

    public class TargetComponent : ITargetComponent
    {
        private AtomicVariable<Entity> target ;

        public TargetComponent(AtomicVariable<Entity> target)
        {
            this.target = target;
        }
        
        public void SetTarget(Entity entity)
        {
            target.Value = entity;
        }
    }
}