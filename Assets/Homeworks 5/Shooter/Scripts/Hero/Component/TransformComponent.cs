using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Component
{
    public interface IGetPositionComponent
    {
        Vector3 Position { get; }
    }
    
    public class TransformComponent : IGetPositionComponent
    {
        private readonly Transform root;
        
        public TransformComponent(Transform root)
        {
            this.root = root;
        }
        
        public Vector3 Position => root.position;
    }
}