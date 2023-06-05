using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    class TestRepository : MonoBehaviour
    {
        public string Name;
        public string Description;
        public Sprite Icon;
        public int Level;
        public int Experiance;

        [Serializable]
        public class Stat
        {
            public string Name;
            public int Value;
        }
        public List<Stat> CharacterStats;

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
    }
}