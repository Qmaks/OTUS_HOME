using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay
{
    [Serializable]
    public class AtomicVariable<T> : IAtomicVariable<T>
    {
        public AtomicEvent<T> OnChanged { get; set; } = new();

        public T Value
        {
            get => value;
            set => SetValue(value);
        }
        
        protected virtual void SetValue(T value)
        {
            this.value = value;
            OnChanged?.Invoke(value);
        }

        [OnValueChanged("OnValueChanged")]
        [SerializeField]
        private T value;

        public AtomicVariable()
        {
            this.value = default;
        }

        public static implicit operator T(AtomicVariable<T> value)
        {
            return value.value;
        }
        
        public AtomicVariable(T value)
        {
            this.value = value;
        }

#if UNITY_EDITOR
        private void OnValueChanged(T value)
        {
            this.OnChanged?.Invoke(value);
        }
#endif
    }
}