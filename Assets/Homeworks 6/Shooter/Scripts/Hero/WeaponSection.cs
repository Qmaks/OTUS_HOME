using System;
using Declarative;
using Lessons.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public sealed class WeaponSection
    {
        [ShowInInspector]
        public AtomicEvent TryShoot = new ();
        
        [ShowInInspector]
        public AtomicEvent OnShooted = new ();

        [SerializeField]
        public TimerMechanics shootCooldown = new();

        [SerializeField]
        public AtomicVariable<int> currentBullet = new();

        [SerializeField]
        public AtomicVariable<int> maxBullet = new();

        [SerializeField]
        public RepeatTimerMechanics restoreBulletTimer = new();

        [SerializeField] public MonoBehaviour coroutineRunner;
        
        [Construct]
        public void Construct()
        {
            restoreBulletTimer.Play();
            restoreBulletTimer.OnCompleted += () =>
            {
                if (currentBullet.Value < maxBullet.Value)
                {
                    currentBullet.Value++;
                }
            };
            
            TryShoot += () =>
            {
                if ((!shootCooldown.IsPlaying) && (currentBullet.Value > 0))
                {
                    currentBullet.Value--;
                    coroutineRunner.StartCoroutine(shootCooldown.Play());
                    OnShooted?.Invoke();
                }
            };
        }
    }
}