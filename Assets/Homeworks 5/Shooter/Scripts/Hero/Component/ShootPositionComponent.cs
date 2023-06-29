using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Component
{
    interface IGetShootPosition
    {
        Vector3 GetShootPosition();
    }
    
    public class ShootPositionComponent : IGetShootPosition
    {
        private readonly Transform shootTransform;

        public ShootPositionComponent(Transform shootTransform)
        {
            this.shootTransform = shootTransform;
        }
        
        public Vector3 GetShootPosition()
        {
            return shootTransform.position;
        }
    }
}