using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks.SaveLoad
{
    public sealed class UnitObject : MonoBehaviour
    {
        [SerializeField]
        public int hitPoints;

        [SerializeField]
        public int speed;

        [SerializeField]
        public int damage;

        [SerializeField] 
        public UnitType type;
    }
}