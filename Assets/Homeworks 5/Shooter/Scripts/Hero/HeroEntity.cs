using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Common;
using Homeworks_5.Shooter.Scripts.Component;
using UnityEngine;
using MoveComponent = Homeworks_5.Shooter.Scripts.Component.MoveComponent;

namespace Homeworks_5.Shooter.Scripts
{
    public class HeroEntity : Entity
    {
        [SerializeField] private HeroModel model;

        private void Awake()
        {
            Add(new TransformComponent(transform));
            Add(new ShootPositionComponent(model.view.shootingPoint.Value));
            Add(new MoveComponent(model.core.moveSection.onMove));
            Add(new LookAtComponent(model.core.lookAt.lookAt));
            Add(new ShootComponent(model.core.weapon.TryShoot,model.core.weapon.OnShooted));
            Add(new AmmoComponent(model.core.weapon.currentBullet,model.core.weapon.maxBullet));
            Add(new HealthComponent(model.core.lifeSection.hitPoints));
            Add(new DeathComponent(this,model.core.lifeSection.isDeath));
            Add(new TakeDamageComponent(model.core.lifeSection.onTakeDamage));
        }
    }
}