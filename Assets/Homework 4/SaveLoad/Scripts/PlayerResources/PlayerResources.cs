using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    public sealed class PlayerResources : MonoBehaviour
    {
        [ShowInInspector]
        private Dictionary<ResourceType, int> resources = new();

        
        public void SetResource(ResourceType resourceType, int resource)
        {
            this.resources[resourceType] = resource;
        }

        public int GetResource(ResourceType resourceType)
        {
            return this.resources[resourceType];
        }

        public void Setup(Dictionary<ResourceType, int> data)
        {
            this.resources = data;
        }

        public Dictionary<ResourceType,int> GetResources()
        {
            return resources;
        }
    }
}