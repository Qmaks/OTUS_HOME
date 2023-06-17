﻿using System;
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
            STONE,
            TREE,
            LIGHT_ARCHER,
            LIGHT_CAVALRY,
            HEAVY_INFANTRY,
            ORC_ARCHER,
            ORC_CATAPULT,
            ORC_SHAMAN
        }
        
        [Serializable]
        public class PrefabTypeHolder
        {
            public ePrefabIDs PrefabID;
            public SavableObject Prefab;
        }
        
        public List<PrefabTypeHolder> Prefabs;

        public SavableObject GetPrefabWithID(string id)
        {
            var prefabID = Enum.Parse<ePrefabIDs>(id);
            foreach (var holder in Prefabs)
            {
                if (holder.PrefabID == prefabID)
                    return holder.Prefab;
            }
            return null;
        }
    }
}