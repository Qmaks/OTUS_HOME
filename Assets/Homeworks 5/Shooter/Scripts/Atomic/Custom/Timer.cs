using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Lessons.Gameplay
{
    [Serializable]
    public sealed class Timer
    {
        public AtomicEvent OnStartPlay { get; set; } = new();
        public AtomicEvent OnCompleted { get; set; } = new();
        
        
        public bool IsPlaying { get; private set; }
        
        [field: SerializeField]
        public float Duration { get; set; }

        public IEnumerator Play()
        {
            if (IsPlaying)
            {
                yield break;
            }

            OnStartPlay.Invoke();
            IsPlaying = true;
            yield return new WaitForSeconds(Duration);
            IsPlaying = false;
            OnCompleted?.Invoke();
        }
    }
}