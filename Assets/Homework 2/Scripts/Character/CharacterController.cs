using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [Inject] private GameManager gameManager;
        [Inject] private BulletConfig bulletConfig;
        [Inject] private BulletSystem bulletSystem;
        [Inject] private CharacterView characterView;
        [Inject] private InputManager inputManager;
        
        private void OnEnable()
        {
            if (characterView!=null)
                characterView.HitPointsComponent.HpEmpty += this.OnCharacterDeath;

            if (inputManager != null)
            {
                inputManager.OnFireButton += BulletShoot;
                inputManager.OnHorizontalDirection += InputManagerOnOnHorizontalDirection;
            }

        }

        private void InputManagerOnOnHorizontalDirection(float horizontal)
        {
            characterView.MoveComponent.MoveByRigidbodyVelocity(new Vector2(horizontal, 0) * Time.fixedDeltaTime);

        }

        private void OnDisable()
        {
            if (characterView!=null)
                characterView.HitPointsComponent.HpEmpty -= this.OnCharacterDeath;
            
            if (inputManager != null)
            {
                inputManager.OnFireButton -= BulletShoot;
                inputManager.OnHorizontalDirection -= InputManagerOnOnHorizontalDirection;
            }
        }

        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();
        
        private void BulletShoot()
        {
            var weapon = characterView.WeaponComponent;
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = true,
                PhysicsLayer = (int) this.bulletConfig.physicsLayer,
                Color = this.bulletConfig.color,
                Damage = this.bulletConfig.damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * this.bulletConfig.speed
            });
        }
    }
}