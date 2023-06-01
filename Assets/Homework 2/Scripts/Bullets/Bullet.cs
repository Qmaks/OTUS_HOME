using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;
        
        [NonSerialized] public bool IsPlayer;
        [NonSerialized] public int Damage;

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

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

        public class Pool : MonoMemoryPool<BulletSpawner.Args,Bullet>
        {
            protected override void Reinitialize(BulletSpawner.Args args, Bullet bullet)
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