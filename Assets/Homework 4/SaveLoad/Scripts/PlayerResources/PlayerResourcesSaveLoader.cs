using System.Collections.Generic;
using Zenject;

namespace Homeworks.SaveLoad
{
    public class PlayerResourcesSaveLoader : SaveLoader<Dictionary<ResourceType, int>,PlayerResources>
    {
        protected override void SetupData(PlayerResources service, Dictionary<ResourceType, int> data)
        {
            service.Setup(data);
        }

        protected override Dictionary<ResourceType, int> ConvertToData(PlayerResources service)
        {
            return service.GetResources();
        }

        protected override void SetupByDefault(PlayerResources service)
        {
            Dictionary<ResourceType, int> data = new()
            {
                { ResourceType.FOOD, 100 },
                { ResourceType.WOOD, 0 },
                { ResourceType.MONEY, 100 },
                { ResourceType.STONE, 0 }
            };

            service.Setup(data);
        }
    }
}