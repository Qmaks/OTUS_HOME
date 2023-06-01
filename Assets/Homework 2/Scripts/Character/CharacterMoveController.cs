using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterMoveController : IInitializable, IDisposable
    {
        [Inject] private CharacterView characterView;
        [Inject] private InputManager inputManager;

        public void Initialize()
        {
            inputManager.OnHorizontalDirection += OnMove;
        }

        public void Dispose()
        {
            inputManager.OnHorizontalDirection -= OnMove;
        }

        private void OnMove(float horizontal)
        {
            characterView.MoveComponent.Move(new Vector2(horizontal, 0) * Time.fixedDeltaTime);
        }
    }
}