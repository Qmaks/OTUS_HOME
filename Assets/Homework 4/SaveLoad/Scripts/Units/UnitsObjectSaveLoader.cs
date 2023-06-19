using System.Collections.Generic;
using System.Linq;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;

namespace Homeworks.SaveLoad
{
    public class UnitsObjectSaveLoader: SaveLoader<List<UnitObjectData>,UnitsManager>
    {
        public UnitsObjectSaveLoader()
        {
            KEY = "UNIT_OBJECTS";
        }
        
        protected override void SetupData(UnitsManager service, List<UnitObjectData> data)
        {
            RemoveNotExistedObjects(service, data);
            SetupFromSaveFile(service, data);
        }

        private static void SetupFromSaveFile(UnitsManager service, List<UnitObjectData> data)
        {
            foreach (var unitData in data)
            {
                UnitObject unit;

                unit = !service.HasUnit(unitData.Name) ? service.Create(unitData.Type) : service.GetUnit(unitData.Name);

                unit.damage = unitData.damage;
                unit.speed = unitData.speed;
                unit.hitPoints = unitData.hitPoints;
                unit.type = unitData.Type;
            }
        }

        private static void RemoveNotExistedObjects(UnitsManager service, List<UnitObjectData> data)
        {
            foreach (var so in service.GetUnits())
            {
                var isNotExistsInSave = !data.Exists((unitData) => unitData.Name == so.gameObject.name);

                if (isNotExistsInSave)
                    service.Remove(so);
            }
        }

        protected override List<UnitObjectData> ConvertToData(UnitsManager service)
        {
            var resources = service.GetUnits();
            
            var data = resources.Select((unit) => new UnitObjectData()
            {
                Name = unit.gameObject.name,
                TransformData = new TransformData(unit.transform),
                damage = unit.damage,
                hitPoints = unit.hitPoints,
                speed = unit.speed,
                Type = unit.type
                
            } ).ToList();

            return data;
        }

        protected override void SetupByDefault(UnitsManager service)
        {
            service.Initialize();
        }
    }
}