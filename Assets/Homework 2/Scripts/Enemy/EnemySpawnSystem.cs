using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemySpawnSystem : MonoBehaviour
    {
        public event Action<GameObject> OnEnemySpawned;
        
        [Inject] private EnemyPool enemyPool;
        
        private readonly HashSet<GameObject> activeEnemies = new();
        
        private IEnumerator Start()
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