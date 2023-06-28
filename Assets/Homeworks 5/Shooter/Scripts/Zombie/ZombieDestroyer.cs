using System;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Common;
using Lessons.Gameplay;
using Zenject;
using Object = UnityEngine.Object;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    public class ZombieDestroyer : IInitializable,IDisposable
    {
        [Inject] private ZombieSpawner zombieSpawner;

        public AtomicVariable<int> ZombieDestroyed = new();

        public void Initialize() =>
            zombieSpawner.OnZombieSpawn += OnZombieSpawn;

        private void OnZombieSpawn(ZombieEntity zombie)
        {
            zombie.Get<IDeathComponent>().OnDeath += DestroyZombie;
        }

        private void DestroyZombie(Entity entity)
        {
            ZombieDestroyed.Value++;
            Object.Destroy(entity.gameObject);
        }

        public void Dispose() =>
            zombieSpawner.OnZombieSpawn -= OnZombieSpawn;
    }
}