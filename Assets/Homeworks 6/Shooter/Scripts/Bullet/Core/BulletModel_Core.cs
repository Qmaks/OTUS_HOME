using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts.Bullet.Core
{
    [Serializable]
    public class BulletModel_Core
    {
        [SerializeField] public MonoBehaviour coroutineRunner;
        
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

        [FormerlySerializedAs("life")]
        [Section]
        [SerializeField]
        public LifeSection lifeSection = new();
        
        [SerializeField]
        public CollisionObservable collisionObservable;
        
        [Construct]
        public void Construct()
        {
            coroutineRunner.StartCoroutine(lifeTimer.Play());
            
            collisionObservable.OnEntered += (collision) =>
            {
                //----------------------------------------------------------------------------------------------------
                // DeathComponent используется как тригер для BulletDestroer
                // Вообще LifeSection решил использовать для пуль, потому что тогда возможна механика
                // прохождение пули через несколько обьктов, при сталкновении с каждым вычиталась бы 1 единица жизни )
                lifeSection.isDeath.Value = true;
                //----------------------------------------------------------------------------------------------------

                var otherEntity = collision.gameObject.GetComponent<Entity>();
                if (otherEntity)
                {
                    otherEntity.Get<ITakeDamageComponent>().ReceiveDamage(damage.Value);
                }
            };
        }
    }
}