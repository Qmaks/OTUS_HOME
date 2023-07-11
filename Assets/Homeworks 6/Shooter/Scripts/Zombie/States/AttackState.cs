using System;
using Lessons.Gameplay;
using Lessons.StateMachines.States;

namespace Homeworks_6.Shooter.Scripts.Zombie.States
{
    [Serializable]
    public class AttackState : UpdateState
    {
        private AtomicEvent _tryAttack;
        
        private Timer _attackTimer;

        public void Construct(AtomicEvent tryAttack,Timer attackTimer)
        {
            _attackTimer = attackTimer;
            _tryAttack = tryAttack;
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            if (!_attackTimer.IsPlaying)
            {
                _tryAttack.Invoke();
            }
        }
    }
}