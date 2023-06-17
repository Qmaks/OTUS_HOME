using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public class GuidComponent : MonoBehaviour
    {
        [SerializeField,InlineButton("CreateGuid")] 
        private string guid = string.Empty;

        public string GuId
        {
            get => guid;
            set => guid = value;
        }
        public void CreateGuid() => guid = Guid.NewGuid().ToString(); 
    }
}