using System;
using Declarative;

namespace Lessons.Gameplay
{
    public sealed class LateUpdateMechanics : ILateUpdateListener
    {
        private Action<float> action;
        
        public void SetAction(Action<float> action)
        {
            this.action = action;
        }

        public void ClearAction() => action = null;
        
        void ILateUpdateListener.LateUpdate(float deltaTime)
        {
            this.action?.Invoke(deltaTime);
        }
    }
}