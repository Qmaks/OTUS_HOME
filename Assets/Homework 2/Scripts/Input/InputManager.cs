using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public event Action OnFireButton;
        public event Action<float> OnHorizontalDirection;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireButton?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnHorizontalDirection?.Invoke(-1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnHorizontalDirection?.Invoke(1);
            }
            else
            {
                OnHorizontalDirection?.Invoke(0);
            }
        }
    }
}