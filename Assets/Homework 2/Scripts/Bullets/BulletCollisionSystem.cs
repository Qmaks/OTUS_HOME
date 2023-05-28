using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletCollisionSystem : IInitializable, IDisposable
    {
        public event Action<Bullet> OnBulletCollision;
        
        [Inject] private BulletSpawnSystem bulletSpawnSystem;

        [Inject] private BulletRemoveSystem bulletRemoveSystem;

        public void Initialize()
        {
            bulletSpawnSystem.OnBulletSpawned += OnBulletSpawn;
            bulletRemoveSystem.OnBulletRemoved += OnBulletRemove;
        }

        public void Dispose()
        {
            bulletSpawnSystem.OnBulletSpawned -= OnBulletSpawn;
            bulletRemoveSystem.OnBulletRemoved -= OnBulletRemove;
        }

        private void OnBulletSpawn(Bullet bullet)
        {
            bullet.collisionHandler.OnCollisionEntered += BulletCollisionHandler;
        }

        private void OnBulletRemove(Bullet bullet)
        {
            bullet.collisionHandler.OnCollisionEntered -= BulletCollisionHandler;
        }

        private void BulletCollisionHandler(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            OnBulletCollision?.Invoke(bullet);
        }
    }
}