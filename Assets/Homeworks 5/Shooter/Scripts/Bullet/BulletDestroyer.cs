using System;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Bullet.Components;
using Homeworks_5.Shooter.Scripts.Common;
using Zenject;
using Object = UnityEngine.Object;

namespace Homeworks_5.Shooter.Scripts.Bullet
{
    public class BulletDestroyer : IInitializable, IDisposable
    {
        [Inject] private BulletSpawner bulletSpawner;
        
        public void Initialize() =>
            bulletSpawner.OnSpawned += OnSpawned;    
        
        public void Dispose() => 
            bulletSpawner.OnSpawned -= OnSpawned;

        private void OnSpawned(BulletEntity bullet)
        {
            bullet.Get<ILifeTimeComponent>().OnLifeTimeEnded += Destroy;
            bullet.Get<IDeathComponent>().OnDeath += Destroy;
        }

        private void Destroy(Entity entity)
        {
            Object.Destroy(entity.gameObject);
        }
    }
}