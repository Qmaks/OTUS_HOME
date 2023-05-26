using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletCollisionSystem : MonoBehaviour
    {
        [Inject] private BulletSpawnSystem bulletSpawnSystem;
        [Inject] private BulletRemoveSystem bulletRemoveSystem;

        private void OnEnable()
        {
            bulletSpawnSystem.OnBulletSpawned += OnBulletSpawn;
            bulletRemoveSystem.OnBulletRemoved += OnBulletRemove;
        }

        private void OnDisable()
        {
            bulletRemoveSystem.OnBulletRemoved -= OnBulletRemove;
        }

        private void OnBulletSpawn(Bullet bullet)
        {
            bullet.collisionHandler.OnCollisionEntered += OnBulletCollision;   
        }

        private void OnBulletRemove(Bullet bullet)
        {
            bullet.collisionHandler.OnCollisionEntered -= OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
        }
    }
}