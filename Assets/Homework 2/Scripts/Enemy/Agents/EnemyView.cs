using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent enemyAttackAgent;
        [SerializeField] private EnemyMoveAgent enemyMoveAgent;
        
        public class Pool : MemoryPool<EnemySpawnSystem.Args,EnemyView>
        {
            protected override void Reinitialize(EnemySpawnSystem.Args args, EnemyView enemy)
            {
                enemy.transform.position = args.Position.position;
                enemy.enemyMoveAgent.SetDestination(args.AttackPosition.position);
                enemy.enemyAttackAgent.SetTarget(args.AttackTarget);
            }
        }
    }
}