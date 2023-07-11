using UnityEngine;
using UnityEngine.Serialization;

namespace Lessons.Gameplay
{
    public class DestroyWithDelay : MonoBehaviour
    {

        public float delayInSeconds;
        
        private void Awake()
        {
            Destroy(gameObject,delayInSeconds);
        }
    }
}