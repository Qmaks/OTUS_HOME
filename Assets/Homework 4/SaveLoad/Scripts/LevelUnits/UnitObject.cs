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

        public void LoadMembers(string[] members)
        {
            hitPoints = int.Parse(members[0]);
            speed = int.Parse(members[1]);
            damage = int.Parse(members[2]);
        }

        public string[] SaveMembers()
        {
            return new[]
            {
                hitPoints.ToString(),
                speed.ToString(),
                damage.ToString()
            };
        }
    }
}