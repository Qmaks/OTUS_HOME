using System.Collections.Generic;
using System.Linq;

namespace Homeworks.SaveLoad
{
    public class ResourcesObjectsSaveLoader : SaveLoader<List<ResourceObjectData>,ResourcesManager>
    {
            public ResourcesObjectsSaveLoader()
            {
                KEY = "RESOURCES_OBJECTS";
            }
        
            protected override void SetupData(ResourcesManager service, List<ResourceObjectData> data)
            {
                foreach (var objectData in data)
                {
                    var resource = service.GetResource(objectData.Name);
                    resource.resourceType = objectData.resourceType;
                    resource.remainingCount = objectData.remainingCount;
                }
            }

            protected override List<ResourceObjectData> ConvertToData(ResourcesManager service)
            {
                var resources = service.GetResources();
                
                var data = resources.Select((keyValue) => new ResourceObjectData()
                {
                    Name = keyValue.Key,
                    resourceType = keyValue.Value.resourceType,
                    remainingCount = keyValue.Value.remainingCount,
                } ).ToList();

                return data;
            }

            protected override void SetupByDefault(ResourcesManager service)
            {
                service.Initialize();
            }
    }
}