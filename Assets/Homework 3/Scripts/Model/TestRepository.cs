using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    class TestRepository : MonoBehaviour
    {
        [SerializeField] private string Name;
        [SerializeField] private string Description;
        [SerializeField] private Sprite Icon;
        [SerializeField] private int Level; 
        [SerializeField] private int Experiance;
        [SerializeField] private List<Stat> CharacterStats;

        public UserInfo GetUserInfo()
        {
            return new UserInfo(Name, Description, Icon);
        }

        public PlayerLevel GetPlayerLevel()
        {
            return new PlayerLevel(Level,Experiance);
        }

        public CharacterInfo GetCharacterInfo()
        {
            var convertedList = CharacterStats.Select(x => new CharacterStat(x.Name, x.Value));
            return new CharacterInfo(convertedList);
        }
        
        [Serializable]
        public class Stat
        {
            public string Name;
            public int Value;
        }
    }
}