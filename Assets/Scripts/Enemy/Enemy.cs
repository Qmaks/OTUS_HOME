using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class Enemy : MonoBehaviour
    {
        public EnemyMoveAgent EnemyMoveAgent;
        public EnemyAttackAgent EnemyAttackAgent;
        public HitPointsComponent HitPointsComponent;
        
        
        public class Pool : MemoryPool<Enemy>
        {
           
        }

    }
}