using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    public sealed class ResourceObject : MonoBehaviour
    {
        [SerializeField]
        public ResourceType resourceType;
        
        [SerializeField]
        public int remainingCount;
    }
}