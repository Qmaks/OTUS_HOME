using System;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts
{
    [Serializable]
    public class HeroModel_View
    {
        [SerializeField]
        public AtomicVariable<Transform> shootingPoint = new();
    }
}