using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Component;
using Lessons.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class ZombieModelCore
    {
        [SerializeField] public AtomicVariable<Entity> target;

        [Section] [SerializeField] public LifeSection lifeSection = new();

        [Section] [SerializeField] public MoveSection moveSection = new();

        [Section] [SerializeField] public MeleeDamageSection damageSection = new();

        [Section] [SerializeField] public IsNearTargetMechanics IsNearTarget = new();

        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct()
        {
           IsNearTarget.Construct(moveSection.moveTransform,target);
            
            fixedUpdate.Do(deltaTime =>
            {
                Run();
                Attack();
            });
            
            SendDamage();
        }

        private void Run()
        {
            var targetPosition = target.Value.Get<IPositionComponent>().Position;
            var myPosition = moveSection.moveTransform.position;
            moveSection.moveTransform.LookAt(targetPosition);
            moveSection.onMove.Invoke((targetPosition - myPosition).normalized);
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