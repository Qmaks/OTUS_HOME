using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemySpawnSystem : IInitializable
    {
        public event Action<GameObject> OnEnemySpawned;

        [Inject] private EnemyPool enemyPool;
        [Inject] private CoroutineRunner coroutineRunner;

        private readonly HashSet<GameObject> activeEnemies = new();

        public void Initialize()
        {
            coroutineRunner.StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
                        OnEnemySpawned?.Invoke(enemy);
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;
                enemyPool.UnspawnEnemy(enemy);
            }
        }
    }
}