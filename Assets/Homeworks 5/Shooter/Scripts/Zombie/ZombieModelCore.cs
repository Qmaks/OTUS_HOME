using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Homeworks_5.Shooter.Scripts.Component;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Zombie
{
    [Serializable]
    public class ZombieModelCore
    {
        [SerializeField] public AtomicVariable<Entity> target;

        [Section] [SerializeField] public Life life = new();

        [Section] [SerializeField] public Move move = new();

        [Section] [SerializeField] public MeleeDamager damager = new();

        [Section] [SerializeField] public IsNearTarget IsNearTarget = new();

        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct()
        {
            fixedUpdate.Do(deltaTime =>
            {
                Run();
                Attack();
            });
            
            SendDamage();
        }

        private void Run()
        {
            var targetPosition = target.Value.Get<IGetPositionComponent>().Position;
            var myPosition = move.moveTransform.position;
            move.moveTransform.LookAt(targetPosition);
            move.onMove.Invoke((targetPosition - myPosition).normalized);
        }

        private void SendDamage()
        {
            damager.attackTimer.OnStartPlay += () =>
            {
                target.Value.Get<ITakeDamageComponent>().ReceiveDamage(damager.damage.Value);
            };
        }

        private void Attack()
        {
            if ((IsNearTarget.value.Value) && (!damager.attackTimer.IsPlaying))
            {
                damager.OnAttack.Invoke();
            }
        }
    }
}