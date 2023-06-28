using System;
using Homeworks_5.Shooter.Scripts.Bullet.Components;
using Zenject;

namespace Homeworks_5.Shooter.Scripts.Bullet
{
    public class BulletSpawner
    {
        public Action<BulletEntity> OnSpawned;
        
        [Inject] private HeroEntity heroEntity;
        [Inject] private BulletFactory bulletFactory;
        
        public void Spawn()
        {
            var bulletEntity = bulletFactory.Create();
            
            bulletEntity.transform.position = heroEntity.model.view.shootingPoint.Value.position;
            var forward = heroEntity.model.transform.forward;
            bulletEntity.Get<IPermanentMotionComponent>().Direction(forward);
            bulletEntity.Get<ILookDirectionComponent>().Direction(forward);
            
            OnSpawned?.Invoke(bulletEntity);
        }
    }
}