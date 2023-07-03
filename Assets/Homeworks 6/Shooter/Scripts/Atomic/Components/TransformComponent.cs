using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Component
{
    public interface IPositionComponent
    {
        Vector3 Position { get; set; }
    }
 
    public interface IGetForwardComponent
    {
        Vector3 Forward { get; }
    }

    
    public class TransformComponent :
        IPositionComponent,
        IGetForwardComponent
    {
        private readonly Transform root;
        
        public TransformComponent(Transform root)
        {
            this.root = root;
        }

        public Vector3 Forward => root.forward;

        public Vector3 Position
        {
            get => root.position; 
            set => root.position = value;
        }
    }
}