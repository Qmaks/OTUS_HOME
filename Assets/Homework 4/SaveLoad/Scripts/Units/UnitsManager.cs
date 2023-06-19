using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Homeworks.SaveLoad
{
    public class UnitsManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform initialPosition;
        [Inject] private UnitFactory factory;
        
        [ShowInInspector,ReadOnly]
        private Dictionary<string, UnitObject> units = new();

        public void Initialize()
        {
            var resourcesObject = FindObjectsOfType<UnitObject>();
            
            try
            {
                units = resourcesObject.ToDictionary((o => o.gameObject.name));

            }
            catch (ArgumentException e)
            {
                Debug.LogError("У объеков должны быть уникальные имена, так как он используются в качестве id");
                Debug.LogError(e.Message);
            }
        }
        
        [Button(ButtonSizes.Large),GUIColor(0,1,0)]
        public UnitObject Create(UnitType type)
        {
            var unit = factory.Create(transform, type);
            if (unit != null)
            {
                unit.transform.position = initialPosition.position;
                units.Add(unit.gameObject.name,unit);
                return unit;
            }

            return null;
        }
        
        [Button(ButtonSizes.Large),GUIColor(0,1,0)]
        public void Remove(UnitObject unit)
        {
            units.Remove(unit.name);
            Destroy(unit.gameObject);
        }
        
        public void SetResource(string name, UnitObject unit)
        {
            units[name] = unit;
        }

        public UnitObject GetUnit(string name)
        {
            return units[name];
        }

        public void Setup(Dictionary<string, UnitObject> data)
        {
            units = data;
        }

        public List<UnitObject> GetUnits()
        {
            return units.Values.ToList();
        }

        public bool HasUnit(string key)
        {
            return units.ContainsKey(key);
        }
    }
}