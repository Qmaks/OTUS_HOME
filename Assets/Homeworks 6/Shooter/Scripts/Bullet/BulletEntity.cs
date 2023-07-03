using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Bullet.Components;
using Homeworks_5.Shooter.Scripts.Common;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Bullet
{
    public class BulletEntity : Entity
    {
        [SerializeField] 
        public BulletModel model;

        private void Awake()
        {
            Add(new PermanentMotionComponent(model.core.move.moveDirection));
            Add(new LookDirectionComponent(model.core.look.lookDirection));
            Add(new LifeTimeComponent(this,model.core.lifeTimer.OnCompleted));
            Add(new CollisionComponent(model.core.collisionObservable));
            Add(new GetDamageComponent(model.core.damage));
            Add(new DeathComponent(this,model.core.lifeSection.isDeath));
        }
    }
}
