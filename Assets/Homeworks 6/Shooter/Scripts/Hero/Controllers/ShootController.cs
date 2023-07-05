using System;
using Homeworks_5.Shooter.Scripts.Bullet;
using Homeworks_5.Shooter.Scripts.Component;
using UnityEngine;
using Zenject;

namespace Homeworks_5.Shooter.Scripts
{
    public class ShootController : IInitializable, IDisposable
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
            var position = heroEntity.Get<IGetShootPosition>().GetShootPosition();
            var direction = heroEntity.Get<IGetForwardComponent>().Forward;
            bulletSpawner.Spawn(position,direction);
        }
    }
}