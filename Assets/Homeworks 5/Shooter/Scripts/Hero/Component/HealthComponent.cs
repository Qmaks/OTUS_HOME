using System;
using Lessons.Gameplay;

namespace Homeworks_5.Shooter.Scripts.Component
{
    interface IHealthComponent
    {
        event Action<int> OnHealthChange;
        int GetHp();
    }
    
    public class HealthComponent : IHealthComponent
    {
        public event Action<int> OnHealthChange;
        
        private readonly AtomicVariable<int> health;

        public int GetHp() => health.Value;

        public HealthComponent(AtomicVariable<int> health)
        {
            this.health = health;
            health.OnChanged += (hp) => OnHealthChange?.Invoke(hp);
        }
    }
}