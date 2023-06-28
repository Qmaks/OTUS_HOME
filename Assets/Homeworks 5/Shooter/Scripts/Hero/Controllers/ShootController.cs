using System;
using Homeworks_5.Shooter.Scripts.Bullet;
using Homeworks_5.Shooter.Scripts.Component;
using UnityEngine;
using Zenject;

namespace Homeworks_5.Shooter.Scripts
{
    public class ShootController : ITickable, IInitializable, IDisposable
    {
        [Inject] private HeroEntity heroEntity;
        [Inject] private BulletSpawner bulletSpawner;

        public void Initialize()
        {
            heroEntity.Get<IShootComponent>().OnShooted += Shoot;
        }

        public void Dispose()
        {
            heroEntity.Get<IShootComponent>().OnShooted -= Shoot;
        }

        private void Shoot()
        {
            bulletSpawner.Spawn();
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                heroEntity.Get<IShootComponent>().Shoot();
            }
        }
    }
}