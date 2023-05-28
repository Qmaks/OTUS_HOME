using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemySpawnSystem : IInitializable , IDisposable
    {
        public event Action<GameObject> OnEnemySpawned;

        [Inject] private EnemyView.Pool enemyPool;
        [Inject] private EnemyPositions enemyPositions;
        [Inject] private CharacterView characterView;
        [Inject] private CoroutineRunner coroutineRunner;

        private readonly HashSet<GameObject> activeEnemies = new();

        public void Initialize()
        {
            coroutineRunner.StartCoroutine(StartSpawn());
        }

        public void Dispose()
        {
            coroutineRunner.StopCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                Args args;
                args.Position = enemyPositions.RandomSpawnPosition();
                args.AttackPosition = enemyPositions.RandomAttackPosition();
                args.AttackTarget = characterView.gameObject;
                
                var enemy = enemyPool.Spawn(args).gameObject;
                
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
                enemyPool.Despawn(enemy.GetComponent<EnemyView>());
            }
        }

        public struct Args
        {
            public Transform Position;
            public Transform AttackPosition;
            public GameObject AttackTarget;
        }
    }
}