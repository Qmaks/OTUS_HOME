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
            hitPoints = (int)(long)members[0];
            speed = (int)(long)members[1];
            damage = (int)(long)members[2];
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