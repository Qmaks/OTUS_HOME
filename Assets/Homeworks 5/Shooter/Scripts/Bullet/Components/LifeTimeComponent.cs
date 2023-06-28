using System;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;

namespace Homeworks_5.Shooter.Scripts.Bullet.Components
{
    interface ILifeTimeComponent
    {
        event Action<Entity> OnLifeTimeEnded;
    }
    
    
    public class LifeTimeComponent : ILifeTimeComponent
    {
        public event Action<Entity> OnLifeTimeEnded;
        private Entity entity;
        
        public LifeTimeComponent(Entity entity, AtomicEvent onLifeTimeEnded)
        {
            this.entity = entity;
            onLifeTimeEnded += () => OnLifeTimeEnded?.Invoke(entity);
        }
    }
}