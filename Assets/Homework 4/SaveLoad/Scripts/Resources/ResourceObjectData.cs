using System;

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