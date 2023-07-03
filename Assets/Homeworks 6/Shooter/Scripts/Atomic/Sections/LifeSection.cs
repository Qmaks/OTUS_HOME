using System;
using Declarative;
using Lessons.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public sealed class LifeSection
    {
        [ShowInInspector]
        public AtomicEvent<int> onTakeDamage = new();

        [SerializeField]
        public AtomicVariable<int> hitPoints = new();

        [SerializeField]
        public AtomicVariable<bool> isDeath;

        [Construct]
        public void Construct()
        {
            onTakeDamage += damage =>
            {
                hitPoints.Value -= damage;
            };
            
            this.hitPoints.OnChanged += hitPoints =>
            {
                if (hitPoints <= 0) this.isDeath.Value = true;
            };
        }
    }
}