using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterMoveSystem : MonoBehaviour
    {
        [Inject] private CharacterView characterView;
        [Inject] private InputManager inputManager;
        
        private void OnEnable()
        {
            inputManager.OnHorizontalDirection += InputManagerOnOnHorizontalDirection;
        }

        private void OnDisable()
        {
            inputManager.OnHorizontalDirection -= InputManagerOnOnHorizontalDirection;
        }

        private void InputManagerOnOnHorizontalDirection(float horizontal)
        {
            characterView.MoveComponent.MoveByRigidbodyVelocity(new Vector2(horizontal, 0) * Time.fixedDeltaTime);
        }
    }
}