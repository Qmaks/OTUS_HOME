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
        
        void CreateGuid()
        { 
            if (guid == Guid.Empty)
                guid = Guid.NewGuid();
        }
        
        protected virtual void Awake()
        {
            CreateGuid();
        }
        
        void OnValidate()
        {
            CreateGuid();
        }
    }
}