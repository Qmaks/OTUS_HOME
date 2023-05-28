using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [Inject] private EnemyPositions enemyPositions;
        [Inject] private CharacterView characterView;
        [Inject] private EnemyView.Factory enemyFactory;

        [SerializeField]
        private Transform worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform container;

        [SerializeField]
        private GameObject prefab;

        private readonly Queue<GameObject> enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < 7; i++)
            {
                var enemy = enemyFactory.Create().gameObject;
                enemy.transform.SetParent(container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!this.enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(characterView.gameObject);
            
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.container);
            enemyPool.Enqueue(enemy);
        }
    }
}