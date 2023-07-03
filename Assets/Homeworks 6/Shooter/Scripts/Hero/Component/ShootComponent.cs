using System;
using Lessons.Gameplay;

namespace Homeworks_5.Shooter.Scripts.Component
{
    interface IShootComponent
    {
        event Action OnShooted;
        void TryShoot();
    }
    
    public class ShootComponent : IShootComponent
    {
        public  event Action OnShooted;
        private AtomicEvent shoot;
        
        public ShootComponent(AtomicEvent shoot, AtomicEvent onShooted)
        {
            this.shoot = shoot;
            onShooted += () => OnShooted?.Invoke();
        }
        
        public void TryShoot()
        {
            shoot.Invoke();
        }
    }
}