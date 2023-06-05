using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class LevelUpButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        
        [Space]
        [SerializeField]
        private Image buttonBackground;
        
        [SerializeField]
        private Sprite ActiveSprite;

        [SerializeField]
        private Sprite LockedSprite;

        [Space]
        [SerializeField]
        private State state;

        public void AddListener(UnityAction action)
        {
            button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            button.onClick.RemoveListener(action);
        }

        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? State.AVAILABLE : State.LOCKED;
            SetState(state);
        }

        public void SetState(State state)
        {
            this.state = state;

            if (state == State.AVAILABLE)
            {
                button.interactable = true;
                this.buttonBackground.sprite = ActiveSprite;
            }
            else if (state == State.LOCKED)
            {
                button.interactable = false;
                this.buttonBackground.sprite = LockedSprite;
            }
            else
            {
                throw new Exception($"Undefined button state {state}!");
            }
        }

        public enum State
        {
            AVAILABLE,
            LOCKED,
        }
    }
}