using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Bullet.Core
{
    [Serializable]
    public class BulletModel_Core
    {
        [SerializeField]
        public AtomicVariable<int> damage = new();
        
        [Section]
        [SerializeField]
        public PermanentLinearMotion move = new();
        
        [Section]
        [SerializeField]
        public LookDirection look = new();

        [SerializeField] 
        public Timer lifeTimer = new();

        [Section]
        [SerializeField]
        public Life life = new();
        
        [SerializeField]
        public CollisionObservable collisionObservable;
        
        [Construct]
        public void Construct()
        {
            lifeTimer.Play();

            collisionObservable.OnEntered += (collision) =>
            {
                life.onTakeDamage.Invoke(life.hitPoints.Value);

                var otherEntity = collision.gameObject.GetComponent<Entity>();
                if (otherEntity)
                {
                    otherEntity.Get<ITakeDamageComponent>().ReceiveDamage(damage.Value);
                }
            };
        }
    }
}