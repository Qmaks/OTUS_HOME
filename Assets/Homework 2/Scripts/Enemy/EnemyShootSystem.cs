using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyShootSystem : MonoBehaviour
    {
        [Inject] private EnemySpawnSystem enemySpawnSystem;
        [Inject] private BulletSpawnSystem bulletSpawnSystem;
        
        private void OnEnable()
        {
            enemySpawnSystem.OnEnemySpawned += OnNewEnemySpawned;
        }
        
        private void OnDisable()
        {
            enemySpawnSystem.OnEnemySpawned -= OnNewEnemySpawned;
        }

        private void OnNewEnemySpawned(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
        }

        private void OnDestroyed(GameObject enemy)
        {
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            bulletSpawnSystem.FlyBulletByArgs(new BulletSpawnSystem.Args
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