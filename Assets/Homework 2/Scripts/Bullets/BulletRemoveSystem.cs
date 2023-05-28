using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletRemoveSystem : IInitializable , IFixedTickable
    {
        public event Action<Bullet> OnBulletRemoved;
        
        [Inject] private LevelBounds levelBounds;
        [Inject] private BulletSpawnSystem bulletSpawnSystem;
        
        private readonly List<Bullet> cache = new();
        private readonly HashSet<Bullet> activeBullets = new();

        public void Initialize()
        {
            bulletSpawnSystem.OnBulletSpawned += OnNewBulletSpawn;
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
            cache.AddRange(this.activeBullets);

            for (int i = 0, count = this.cache.Count; i < count; i++)
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