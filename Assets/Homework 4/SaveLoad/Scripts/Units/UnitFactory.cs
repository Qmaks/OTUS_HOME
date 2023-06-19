using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using UnityEngine;
using Zenject;

namespace Homeworks.SaveLoad
{
    public class UnitFactory : PlaceholderFactory<Transform, UnitType, UnitObject>
    {
        [Inject] private UnitsPrefabDatabase prefabDatabase;
        [Inject] private DiContainer container;

        public override UnitObject Create(Transform parent, UnitType type)
        {
            var prefab = prefabDatabase.GetPrefabWithType(type);
            var instance = container.InstantiatePrefabForComponent<UnitObject>(prefab);
            instance.transform.SetParent(parent);
            return instance;
        }
    }
}