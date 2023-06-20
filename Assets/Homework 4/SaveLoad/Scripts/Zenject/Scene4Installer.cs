using Homework_4.SaveLoad.Scripts.Encrypt;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem.Serializer;
using Homeworks.SaveLoad;
using UnityEngine;
using Zenject;

public class Scene4Installer : MonoInstaller
{
    [SerializeField] private UnitsPrefabDatabase unitsPrefabDatabase;
    
    public override void InstallBindings()
    {
        //Database...
        Container.Bind<UnitsPrefabDatabase>().FromInstance(unitsPrefabDatabase).AsSingle();
        
        //Services...
        Container.BindInterfacesAndSelfTo<SaveLoadManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerResources>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<ResourcesManager>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<UnitsManager>().FromComponentInHierarchy().AsSingle();
        
        //Repository...
        Container.BindInterfacesTo<GameRepository>().FromNew().AsSingle().NonLazy();
        Container.Bind<IEncryptor>().To<Encryptor>().FromNew().AsSingle();
        Container.Bind<ISerializer>().To<Serializer>().FromNew().AsSingle();
        
        //SaveLoaders...
        Container.BindInterfacesTo<ResourcesObjectsSaveLoader>().FromNew().AsCached();
        Container.BindInterfacesTo<PlayerResourcesSaveLoader>().FromNew().AsCached();
        Container.BindInterfacesTo<UnitsObjectSaveLoader>().FromNew().AsCached();

        //Factory...
        Container.BindFactory<Transform, UnitType, UnitObject, UnitFactory>();
    }

}
