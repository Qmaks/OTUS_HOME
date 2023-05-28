using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(Bullet))]
    public class BulletCollisionHandler : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        
        public event Action<Bullet, Collision2D> OnCollisionEntered;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(bullet, collision);
        }
    }
}