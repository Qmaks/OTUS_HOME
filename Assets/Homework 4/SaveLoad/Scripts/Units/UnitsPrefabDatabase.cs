using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    [CreateAssetMenu(menuName = "Save System/Units Prefab Database")]
    public class UnitsPrefabDatabase : ScriptableObject
    {
        [Serializable]
        public class TypeHolder
        {
            public UnitType Type;
            public UnitObject Prefab;
        }
        
        public List<TypeHolder> Prefabs;

        public UnitObject GetPrefabWithType(UnitType type)
        {
            foreach (var holder in Prefabs)
            {
                if (holder.Type == type)
                    return holder.Prefab;
            }
            return null;
        }
    }
}