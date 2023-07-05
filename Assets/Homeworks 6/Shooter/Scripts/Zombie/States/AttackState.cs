using System;
using Lessons.Gameplay;
using Lessons.StateMachines.States;

namespace Homeworks_6.Shooter.Scripts.Zombie.States
{
    [Serializable]
    public class AttackState : IState
    {
        private AtomicEvent _tryAttack;
        
        private LateUpdateMechanics lateUpdateMechanics = new();
        private TimerMechanics _attackTimer;

        public void Construct(AtomicEvent tryAttack,TimerMechanics attackTimer)
        {
            _attackTimer = attackTimer;
            _tryAttack = tryAttack;
        }

        public void Enter()
        {
            lateUpdateMechanics.SetAction((detaTime) =>
            {
                if (!_attackTimer.IsPlaying)
                {
                    _tryAttack.Invoke();
                }
            });
        }

        public void Exit()
        {
            lateUpdateMechanics.ClearAction();
        }
    }
}