using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletSpawner : IInitializable, IDisposable
    {
        public event Action<Bullet> OnBulletSpawned;
        
        [Inject] private Bullet.Pool bulletPool;

        [Inject] private BulletDestroyer bulletDestroyer;

        public void Initialize()
        {
            bulletDestroyer.OnBulletRemoved += OnBulletRemoved;
        }

        public void Dispose()
        {
            bulletDestroyer.OnBulletRemoved -= OnBulletRemoved;
        }

        private void OnBulletRemoved(Bullet bullet)
        {
            bulletPool.Despawn(bullet);
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = bulletPool.Spawn(args);
            OnBulletSpawned?.Invoke(bullet);
        }

        public struct Args
        {
            public Vector2 Position;
            public Vector2 Velocity;
            public Color Color;
            public int PhysicsLayer;
            public int Damage;
            public bool IsPlayer;
        }
    }
}