using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletDamager :  IInitializable, IDisposable
    {
        [Inject] private BulletSpawner bulletSpawner;
        [Inject] private BulletDestroyer bulletDestroyer;

        public void Initialize()
        {
            bulletSpawner.OnBulletSpawned += OnBulletSpawn;
            bulletDestroyer.OnBulletRemoved += OnBulletRemove;
        }

        public void Dispose()
        {
            bulletSpawner.OnBulletSpawned -= OnBulletSpawn;
            bulletDestroyer.OnBulletRemoved -= OnBulletRemove;
        }

        private void OnBulletSpawn(Bullet bullet)
        {
            bullet.OnCollisionEntered += DealDamage;
        }

        private void OnBulletRemove(Bullet bullet)
        {
            bullet.OnCollisionEntered -= DealDamage;
        }

        private void DealDamage(Bullet bullet, Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }
    }
}