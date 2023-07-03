using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Lessons.Gameplay
{
    [Serializable]
    public sealed class RepeatTimerMechanics
    {
        public AtomicEvent OnCompleted { get; set; } = new();
        
        public bool IsPlaying { get; private set; }
        
        [field: SerializeField]
        public float Duration { get; set; }

        public async void Play()
        {
            if (IsPlaying)
            {
                return;
            }
            
            IsPlaying = true;

            while (true)
            {
                await UniTask.Delay(Mathf.RoundToInt(Duration * 1000));
                OnCompleted?.Invoke();
            }
        }
    }
}