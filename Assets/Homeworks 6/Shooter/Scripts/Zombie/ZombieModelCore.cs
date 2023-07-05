using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Component;
using Homeworks_6.Shooter.Scripts.Zombie;
using Lessons.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class ZombieModelCore
    {
        [SerializeField] public MonoBehaviour coroutineRunner;
        
        [SerializeField] public AtomicVariable<Entity> target;

        [Section] [SerializeField] public LifeSection lifeSection = new();

        [Section] [SerializeField] public MoveSection moveSection = new();

        [Section] [SerializeField] public MeleeDamageSection damageSection = new();

        [Section] [SerializeField] public IsNearTargetMechanics IsNearTarget = new();

        [Section] [SerializeField] public ZombieStates zombieStates;

        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct()
        {
            IsNearTarget.Construct(moveSection.transform,target);
            
            // fixedUpdate.Do(deltaTime =>
            // {
            //     Run();
            //     Attack();
            // });
            
            SendDamage();
        }

        private void Run()
        {
            var targetPosition = target.Value.Get<IPositionComponent>().Position;
            var myPosition = moveSection.transform.position;
            moveSection.movementDirection.Value = (targetPosition - myPosition).normalized; 
        }

        private void SendDamage()
        {
            damageSection.attackTimer.OnStartPlay += () =>
            {
                target.Value.Get<ITakeDamageComponent>().ReceiveDamage(damageSection.damage.Value);
            };
        }

        private void Attack()
        {
            if ((IsNearTarget.value.Value) && (!damageSection.attackTimer.IsPlaying))
            {
                damageSection.OnAttack.Invoke();
            }
        }
    }
}