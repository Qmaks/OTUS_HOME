using System;
using Homeworks_5.Shooter.Scripts.Bullet.Components;
using UnityEngine;
using Zenject;

namespace Homeworks_5.Shooter.Scripts.Bullet
{
    public class BulletSpawner
    {
        public Action<BulletEntity> OnSpawned;
        
        [Inject] private BulletFactory bulletFactory;
        
        public void Spawn(Vector3 position,Vector3 direction)
        {
            var bulletEntity = bulletFactory.Create();

            bulletEntity.transform.position = position;
            bulletEntity.Get<IPermanentMotionComponent>().Direction(direction);
            bulletEntity.Get<ILookDirectionComponent>().Direction(direction);
            
            OnSpawned?.Invoke(bulletEntity);
        }
    }
}