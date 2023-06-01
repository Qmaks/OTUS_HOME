using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent enemyAttackAgent;
        [SerializeField] private EnemyMoveAgent enemyMoveAgent;
        
        public class Pool : MonoMemoryPool<EnemySpawner.Args,EnemyView>
        {
            protected override void Reinitialize(EnemySpawner.Args args, EnemyView enemy)
            {
                enemy.transform.position = args.Position.position;
                enemy.enemyMoveAgent.SetDestination(args.AttackPosition.position);
                enemy.enemyAttackAgent.SetTarget(args.AttackTarget);
            }
        }
    }
}