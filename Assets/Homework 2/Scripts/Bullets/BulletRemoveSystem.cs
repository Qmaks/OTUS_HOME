using System;
using System.Collections.Generic;
using Zenject;

namespace ShootEmUp
{
    public class BulletRemoveSystem : IInitializable , IDisposable, IFixedTickable
    {
        public event Action<Bullet> OnBulletRemoved;
        
        [Inject] private LevelBounds levelBounds;
        [Inject] private BulletSpawnSystem bulletSpawnSystem;
        [Inject] private BulletCollisionSystem bulletCollisionSystem;
        
        private readonly List<Bullet> cache = new();
        private readonly HashSet<Bullet> activeBullets = new();

        public void Initialize()
        {
            bulletSpawnSystem.OnBulletSpawned += OnNewBulletSpawn;
            bulletCollisionSystem.OnBulletCollision += OnBulletCollision;
        }

        public void Dispose()
        {
            bulletSpawnSystem.OnBulletSpawned -= OnNewBulletSpawn;
            bulletCollisionSystem.OnBulletCollision -= OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet)
        {
            RemoveBullet(bullet);
        }

        private void OnNewBulletSpawn(Bullet bullet)
        {
            activeBullets.Add(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            OnBulletRemoved?.Invoke(bullet);
            activeBullets.Remove(bullet);
        }

        public void FixedTick()
        {
            cache.Clear();
            cache.AddRange(activeBullets);

            for (int i = 0, count = cache.Count; i < count; i++)
            {
                var bullet = this.cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }
    }
}