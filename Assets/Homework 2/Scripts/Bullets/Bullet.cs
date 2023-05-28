using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        [NonSerialized] public bool IsPlayer;
        [NonSerialized] public int Damage;
        public BulletCollisionHandler collisionHandler;

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
        }

        private void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        private void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
        
        public class Pool : MonoMemoryPool<BulletSpawnSystem.Args,Bullet>
        {
            protected override void Reinitialize(BulletSpawnSystem.Args args, Bullet bullet)
            {
                bullet.SetPosition(args.Position);
                bullet.SetColor(args.Color);
                bullet.SetPhysicsLayer(args.PhysicsLayer);
                bullet.Damage = args.Damage;
                bullet.IsPlayer = args.IsPlayer;
                bullet.SetVelocity(args.Velocity);
            }
        }
    }
}