using UnityEngine;

namespace Lessons.Gameplay
{
    public sealed class CollisionObservable : MonoBehaviour
    {
        public AtomicEvent<Collision> OnEntered;
        public AtomicEvent<Collision> OnExited;

        private void OnCollisionEnter(Collision collision)
        {
            OnEntered?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            OnExited?.Invoke(collision);
        }
    }
}