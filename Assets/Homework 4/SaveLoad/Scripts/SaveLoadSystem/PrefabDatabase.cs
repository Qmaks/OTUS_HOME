using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    [CreateAssetMenu(menuName = "Save System/Prefab Database")]
    public class PrefabDatabase : SerializedScriptableObject
    {
        [Serializable]
        public enum ePrefabIDs
        {
            NONE,
            STONE,
            TREE
        }
        
        [Serializable]
        public class PrefabTypeHolder
        {
            [FormerlySerializedAs("PrefabType")] public ePrefabIDs prefabID;
            public GameObject Prefab;
        }
        
        public List<PrefabTypeHolder> m_Prefabs;
    }
}