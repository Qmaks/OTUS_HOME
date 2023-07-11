using System;
using System.Linq;
using Cysharp.Threading.Tasks;
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

        public float Radius = 100;

        [SerializeField]
        private Transform transform;

        [ShowInInspector,ReadOnly]
        public bool Active { get; set; } = false;
        
        private void TryFind()
        {
            var colliders = Physics.OverlapSphere(transform.position,Radius);

            var objects = colliders.Select(collider => collider.gameObject.GetComponent<T>()).OfType<T>().ToArray();
            
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