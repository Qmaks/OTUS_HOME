﻿using System;
using Declarative;
using Homeworks_6.Shooter.Scripts.Atomic.Mechanics;
using Lessons.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public sealed class ShootSection
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
        public LoopTimer restoreBulletTimer = new();

        [SerializeField]
        public NearestTargetSensor<ZombieEntity> nearestZombieSensor = new();
        
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