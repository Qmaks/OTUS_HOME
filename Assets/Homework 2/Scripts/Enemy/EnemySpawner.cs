using System;
using System.Collections;
using System.Collections.Generic;
using ShootEmUp.Generators;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemySpawner : IInitializable , IDisposable
    {
        public event Action<GameObject> OnEnemySpawned;
        
        [Inject] private EnemyView.Pool enemyPool;
        [Inject] private EnemyPositions enemyPositions;
        [Inject] private CharacterView characterView;
        [Inject] private CoroutineRunner coroutineRunner;
        [Inject] private Generator generator;

        public void Initialize()
        {
            generator.OnGenerated += SpawnEnemy;
            coroutineRunner.StartCoroutine(generator.StartGenerate());
        }

        public void Dispose()
        {
            generator.OnGenerated -= SpawnEnemy;
            coroutineRunner.StopCoroutine(generator.StartGenerate());
        }

        private void SpawnEnemy()
        {
            Args args;
            args.Position = enemyPositions.RandomSpawnPosition();
            args.AttackPosition = enemyPositions.RandomAttackPosition();
            args.AttackTarget = characterView.gameObject;
                
            var enemy = enemyPool.Spawn(args).gameObject;
                
            if (enemy != null)
            {
                OnEnemySpawned?.Invoke(enemy);
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