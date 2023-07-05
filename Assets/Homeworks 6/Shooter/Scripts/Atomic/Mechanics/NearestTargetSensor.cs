using System;
using Declarative;
using Homeworks_5.Shooter.Scripts.Atomic;
using Lessons.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks_6.Shooter.Scripts.Atomic.Mechanics
{
    [Serializable]
    public class NearestTargetSensor<T> : IUpdateListener where T : Entity
    {
        public AtomicVariable<T> Target;
        
        [SerializeField]
        private Transform transform;

        [ShowInInspector,ReadOnly]
        public bool Active { get; set; } = false;
        
        private void TryFind()
        {
            var objects = GameObject.FindObjectsOfType<T>();
            T foundObjects = null;
            
            foreach (T obj in objects)
            {
                var objTransform = obj.transform;
                var distance = Vector3.Distance(transform.position, objTransform.position);
                
                if (foundObjects == null || distance < Vector3.Distance(transform.position, (foundObjects.transform.position)))
                {
                    foundObjects = obj;
                }
            }

            if (foundObjects != null)
            {
                Target.Value = foundObjects;
            }
        }

        public void Update(float deltaTime)
        {
            if (Active)
            {
                TryFind();
            }
        }
    }
}