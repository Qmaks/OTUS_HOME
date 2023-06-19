using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Homeworks.SaveLoad
{
    public class ResourcesManager : MonoBehaviour, IInitializable
    {
        [ShowInInspector]
        private Dictionary<string, ResourceObject> resources = new();

        public void Initialize()
        {
            var resourcesObject = FindObjectsOfType<ResourceObject>();
            
            try
            {
                resources = resourcesObject.ToDictionary((o => o.gameObject.name));

            }
            catch (ArgumentException e)
            {
                Debug.LogError("У объеков должны быть уникальные имена так как он используются в качестве id");
                Debug.LogError(e.Message);
            }
        }
        
        public void SetResource(string name, ResourceObject resource)
        {
            resources[name] = resource;
        }

        public ResourceObject GetResource(string name)
        {
            return resources[name];
        }

        public void Setup(Dictionary<string, ResourceObject> data)
        {
            resources = data;
        }

        public Dictionary<string,ResourceObject> GetResources()
        {
            return resources;
        }
    }
}