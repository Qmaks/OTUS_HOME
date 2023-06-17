using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    public sealed class UnitObject : MonoBehaviour, ISaveableComponent
    {
        [SerializeField]
        public int hitPoints;

        [SerializeField]
        public int speed;

        [SerializeField]
        public int damage;

        public void LoadMembers(object[] members)
        {
            hitPoints = (int)members[0];
            speed = (int)members[1];
            damage = (int)members[2];
        }

        public object[] SaveMembers()
        {
            return new object[]
            {
                hitPoints,
                speed,
                damage
            };
        }
    }
}