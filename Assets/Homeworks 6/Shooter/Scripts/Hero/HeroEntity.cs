using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Common;
using Homeworks_5.Shooter.Scripts.Component;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    public class HeroEntity : Entity
    {
        [SerializeField] private HeroModel model;

        private void Awake()
        {
            Add(new TransformComponent(transform));
            Add(new ShootPositionComponent(model.view.shootingPoint.Value));
            Add(new MoveInDirectionComponent(model.core.moveSection.movementDirection));
            Add(new ShootComponent(model.core.shootSection.TryShoot,model.core.shootSection.OnShooted));
            Add(new AmmoComponent(model.core.shootSection.currentBullet,model.core.shootSection.maxBullet));
            Add(new HealthComponent(model.core.lifeSection.hitPoints));
            Add(new DeathComponent(this,model.core.lifeSection.isDeath));
            Add(new TakeDamageComponent(model.core.lifeSection.onTakeDamage));
        }
    }
}