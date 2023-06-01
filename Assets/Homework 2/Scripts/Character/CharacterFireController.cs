using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterFireController : IInitializable , IDisposable
    {
        [Inject] private CharacterView characterView;
        [Inject] private BulletConfig bulletConfig;
        [Inject] private BulletSpawner bulletSpawner;
        [Inject] private InputManager inputManager;
        
        public void Initialize()
        {
            inputManager.OnFireButton += BulletShoot; 
        }

        public void Dispose()
        {
            inputManager.OnFireButton -= BulletShoot; 
        }

        private void BulletShoot()
        {
            var weapon = characterView.WeaponComponent;
            bulletSpawner.FlyBulletByArgs(new BulletSpawner.Args
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