using System;
using Lessons.Gameplay;

namespace Homeworks_5.Shooter.Scripts.Component
{
    interface IAmmoComponent
    {
        event Action<int> OnUpdateAmmo;
        
        int GetCurrentAmmo();
        int GetMaxAmmo();
    }
    
    public class AmmoComponent : IAmmoComponent
    {
        public event Action<int> OnUpdateAmmo;
        
        private AtomicVariable<int> currentAmmo;
        private AtomicVariable<int> maxAmmo;

        public AmmoComponent(AtomicVariable<int> currentAmmo,AtomicVariable<int> maxAmmo)
        {
            this.currentAmmo = currentAmmo;
            this.maxAmmo = maxAmmo;

            this.currentAmmo.OnChanged += (count) => OnUpdateAmmo?.Invoke(count);
        }

        public int GetCurrentAmmo()
        {
            return currentAmmo.Value;
        }
        
        public int GetMaxAmmo()
        {
            return maxAmmo.Value;
        }
    }
}