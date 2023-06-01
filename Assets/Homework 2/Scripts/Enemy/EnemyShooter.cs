using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyShooter : IInitializable , IDisposable
    {
        [Inject] private EnemySpawner enemySpawner;
        [Inject] private BulletSpawner bulletSpawner;

        public void Initialize()
        {
            enemySpawner.OnEnemySpawned += OnEnemySpawned;
        }

        public void Dispose()
        {
            enemySpawner.OnEnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire += Shoot;
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= Shoot;
        }

        private void Shoot(GameObject enemy, Vector2 position, Vector2 direction)
        {
            bulletSpawner.FlyBulletByArgs(new BulletSpawner.Args
            {
                IsPlayer = false,
                PhysicsLayer = (int) PhysicsLayer.ENEMY_BULLET,
                Color = Color.red,
                Damage = 1,
                Position = position,
                Velocity = direction * 2.0f
            });
        }
    }
}