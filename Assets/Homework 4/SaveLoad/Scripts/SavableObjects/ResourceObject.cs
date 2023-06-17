using System;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using ModestTree;
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
        public void LoadMembers(object[] members)
        {
            resourceType   = (ResourceType)members[1];
            remainingCount = (int)members[1];
        }

        public object[] SaveMembers()
        {
            return new object[]
            {
                resourceType,
                remainingCount
            };
        }
        #endregion
    }
}