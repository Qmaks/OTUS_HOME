using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterMoveSystem : IInitializable
    {
        [Inject] private CharacterView characterView;
        [Inject] private InputManager inputManager;

        public void Initialize()
        {
            inputManager.OnHorizontalDirection += InputManagerOnOnHorizontalDirection;
        }

        private void InputManagerOnOnHorizontalDirection(float horizontal)
        {
            characterView.MoveComponent.MoveByRigidbodyVelocity(new Vector2(horizontal, 0) * Time.fixedDeltaTime);
        }
    }
}