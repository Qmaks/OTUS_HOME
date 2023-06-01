using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        public Transform[] spawnPositions;
        public Transform[] attackPositions;
        
        public Transform RandomSpawnPosition()
        {
            return RandomTransform(spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}