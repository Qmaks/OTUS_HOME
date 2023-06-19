using System;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;

namespace Homeworks.SaveLoad
{
    [Serializable]
    public class ResourceObjectData
    {
        public string Name;
        public ResourceType resourceType;
        public int remainingCount;
    }
}