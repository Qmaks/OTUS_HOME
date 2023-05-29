using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPositions
    {
        [Inject] private EnemyPositionSceneLinks links;
        
        public Transform RandomSpawnPosition()
        {
            return RandomTransform(links.spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(links.attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}