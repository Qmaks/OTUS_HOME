using System.Collections.Generic;
using System.Linq;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;

namespace Homeworks.SaveLoad.LevelResources
{
    public class SavableObjectsSaveLoader : SaveLoader<List<SavableObject.Data>,SavableObjectsManager>
    {
        protected override void SetupData(SavableObjectsManager service, List<SavableObject.Data> data)
        {
            service.Setup(data);
        }

        protected override List<SavableObject.Data> ConvertToData(SavableObjectsManager service)
        {
            return service.GetObjects().ToList();
        }

        protected override void SetupByDefault(SavableObjectsManager service)
        {
            service.InitializeFromScene();
        }
    }
}