using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public class GuidComponent : SerializedMonoBehaviour
    {
        [SerializeField] 
        private Guid guid = Guid.Empty;
        
        public bool IsGuidAssigned()
        {
            return guid != Guid.Empty;
        }
        
        public Guid GetGuid()
        {
            return guid;
        }
        
        public void SetGuid(string value)
        {
            guid = new Guid(value);
        }
        
        public void CreateGuid()
        { 
            guid = Guid.NewGuid();
        }
    }
}