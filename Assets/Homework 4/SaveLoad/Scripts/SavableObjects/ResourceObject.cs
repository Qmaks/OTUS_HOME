using System;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    public sealed class ResourceObject : MonoBehaviour, ISaveableComponent
    {
        [SerializeField]
        public ResourceType resourceType;
        
        [SerializeField]
        public int remainingCount;

        #region SaveLoad
        public void LoadMembers(string[] members)
        {
            resourceType   = Enum.Parse<ResourceType>(members[0]);
            remainingCount = int.Parse(members[1]);
        }

        public string[] SaveMembers()
        {
            return new[]
            {
                resourceType.ToString(),
                remainingCount.ToString()
            };
        }
        #endregion
    }
}