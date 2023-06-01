using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletDestroyer : IInitializable , IDisposable, IFixedTickable
    {
        public event Action<Bullet> OnBulletRemoved;
        
        [Inject] private LevelBounds levelBounds;
        [Inject] private BulletSpawner bulletSpawner;
        
        private readonly List<Bullet> cache = new();
        private readonly HashSet<Bullet> activeBullets = new();

        public void Initialize()
        {
            bulletSpawner.OnBulletSpawned += OnNewBulletSpawn;
        }

        public void Dispose()
        {
            bulletSpawner.OnBulletSpawned -= OnNewBulletSpawn;
        }

        private void OnNewBulletSpawn(Bullet bullet)
        {
            bullet.OnCollisionEntered += OnBulletCollision; 
            activeBullets.Add(bullet);
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            bullet.OnCollisionEntered -= OnBulletCollision; 
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