using System;
using Declarative;
using Lessons.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    //TODO : Разделить на 2 компонента
    [Serializable]
    public sealed class Weapon
    {
        [ShowInInspector]
        public AtomicEvent TryShoot = new ();
        
        [ShowInInspector]
        public AtomicEvent OnShooted = new ();

        [SerializeField]
        public Timer shootCooldown = new();

        [SerializeField]
        public AtomicVariable<int> currentBullet = new();

        [SerializeField]
        public AtomicVariable<int> maxBullet = new();

        [SerializeField]
        public RepeatTimer restoreBulletTimer = new();

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
                    shootCooldown.Play();
                    OnShooted?.Invoke();
                }
            };
        }
    }
}