using System;
using Lessons.Gameplay;
using Lessons.StateMachines.States;
using UnityEngine;

namespace Homeworks_6.Shooter.Scripts.Zombie.States
{
    [Serializable]
    public class DeathState : IState
    {
        private MonoBehaviour _coroutineRunner;
        private TimerMechanics _deathTimer;

        public void Construct(MonoBehaviour coroutineRunner,TimerMechanics deathTimer)
        {
            _deathTimer = deathTimer;
            _coroutineRunner = coroutineRunner;
        }
        
        public void Enter()
        {
            _coroutineRunner.StartCoroutine(_deathTimer.Play());
        }

        public void Exit()
        {
            _coroutineRunner.StopCoroutine(_deathTimer.Play());
        }
    }
}