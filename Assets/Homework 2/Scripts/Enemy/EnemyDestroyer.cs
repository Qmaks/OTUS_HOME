using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyDestroyer :  IInitializable , IDisposable
    {
        [Inject] private EnemyView.Pool enemyPool;
        [Inject] private EnemySpawner enemySpawner;
        
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
            enemy.GetComponent<HitPointsComponent>().HpEmpty += DestroyEnemy;
        }

        private void DestroyEnemy(GameObject enemy)
        {
            enemyPool.Despawn(enemy.GetComponent<EnemyView>());
        }
    }
}