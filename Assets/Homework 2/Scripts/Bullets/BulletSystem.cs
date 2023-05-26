using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [Inject] private LevelBounds levelBounds;
        [Inject] private Bullet.Pool bulletPool;

        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();
        
        private void FixedUpdate()
        {
            this.cache.Clear();
            this.cache.AddRange(this.activeBullets);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var bullet = this.cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = bulletPool.Spawn(args);
            
            if (this.activeBullets.Add(bullet))
            {
                bullet.collisionHandler.OnCollisionEntered += this.OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (activeBullets.Remove(bullet))
            {
                bullet.collisionHandler.OnCollisionEntered -= this.OnBulletCollision;
                bulletPool.Despawn(bullet);
            }
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