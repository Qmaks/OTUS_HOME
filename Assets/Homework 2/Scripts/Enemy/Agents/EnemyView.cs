using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent enemyAttackAgent;
        [SerializeField] private EnemyMoveAgent enemyMoveAgent;
        
        public class Factory : PlaceholderFactory<EnemyView>
        {
        }
    }
}