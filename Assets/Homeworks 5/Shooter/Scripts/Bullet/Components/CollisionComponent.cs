using System;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.Bullet.Components
{
    interface ICollisionComponent
    {
        event Action<Entity,Collision> OnCollided;
    }
    
    
    public class CollisionComponent : ICollisionComponent
    {
        public event Action<Entity, Collision> OnCollided;

        public CollisionComponent(CollisionObservable observable)
        {
           // observable.OnEntered += (entity, collision) => OnCollided?.Invoke(entity,collision);
        }
    }
}