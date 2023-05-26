using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletSpawnSystem : MonoBehaviour
    {
        public event Action<Bullet> OnBulletSpawned;
        
        [Inject] private Bullet.Pool bulletPool;
        [Inject] private BulletRemoveSystem bulletRemoveSystem;

        private void OnEnable()
        {
            bulletRemoveSystem.OnBulletRemoved += OnBulletRemoved;
        }

        private void OnDisable()
        {
            bulletRemoveSystem.OnBulletRemoved -= OnBulletRemoved;
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