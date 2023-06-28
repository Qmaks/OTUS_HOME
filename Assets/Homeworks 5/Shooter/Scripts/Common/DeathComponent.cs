using System;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;

namespace Homeworks_5.Shooter.Scripts.Common
{
    interface IDeathComponent
    {
        event Action<Entity> OnDeath;
    }
    
    public class DeathComponent : IDeathComponent
    {
        public event Action<Entity> OnDeath;
        
        public DeathComponent(Entity entity,AtomicVariable<bool> isDeath)
        {
            isDeath.OnChanged += (death) =>
            {
                if (death)
                    OnDeath?.Invoke(entity);
            };
        }
    }
}