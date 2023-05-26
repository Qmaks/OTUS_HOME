using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterFireSystem : MonoBehaviour
    {
        [Inject] private CharacterView characterView;
        [Inject] private BulletConfig bulletConfig;
        [Inject] private BulletSpawnSystem bulletSpawnSystem;
        [Inject] private InputManager inputManager;
        
        private void OnEnable()
        {
            inputManager.OnFireButton += BulletShoot; 
        }

        private void OnDisable()
        {
            inputManager.OnFireButton -= BulletShoot; 
        }

        private void BulletShoot()
        {
            var weapon = characterView.WeaponComponent;
            bulletSpawnSystem.FlyBulletByArgs(new BulletSpawnSystem.Args
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