using System;
using Sirenix.OdinInspector;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public class GuidComponent : MonoBehaviour
    {
        [SerializeField,InlineButton("CreateGuid")] 
        private string guid = string.Empty;
        
        public string GetGuid()
        {
            return guid;
        }
        
        public void SetGuid(string value)
        {
            guid = value;
        }
        
        public void CreateGuid()
        { 
            guid = Guid.NewGuid().ToString();
        }
    }
}