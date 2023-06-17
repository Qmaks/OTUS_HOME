using System.Collections.Generic;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;

namespace Homeworks.SaveLoad.LevelResources
{
    public class SavableObjectsSaveLoader : SaveLoader<Dictionary<string,SavableObject.Data>,SavableObjectsManager>
    {
        public SavableObjectsSaveLoader()
        {
            KEY = "SAVABLE_OBJECTS";
        }
        
        protected override void SetupData(SavableObjectsManager service, Dictionary<string,SavableObject.Data> data)
        {
            service.Setup(data);
        }

        protected override Dictionary<string,SavableObject.Data> ConvertToData(SavableObjectsManager service)
        {
            return service.GetObjects();
        }
    }
}