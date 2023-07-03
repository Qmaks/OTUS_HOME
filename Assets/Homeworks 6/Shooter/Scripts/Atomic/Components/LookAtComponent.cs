using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Component
{
    public interface ILookAtComponent
    {
        void LookAt(Vector3 point);
    }

    public sealed class LookAtComponent : ILookAtComponent
    {
        private readonly IAtomicVariable<Vector3> lookPoint;

        public LookAtComponent(IAtomicVariable<Vector3> lookPoint)
        {
            this.lookPoint = lookPoint;
        }

        public void LookAt(Vector3 point)
        {
            lookPoint.Value = point;
        }
    }
}