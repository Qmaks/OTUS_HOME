using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using Homeworks.SaveLoad;
using Homeworks.SaveLoad.LevelResources;
using UnityEngine;
using Zenject;

public class Scene4Installer : MonoInstaller
{
    [SerializeField] private PrefabDatabase prefabDatabase;
    
    public override void InstallBindings()
    {
        //Database...
        Container.Bind<PrefabDatabase>().FromInstance(prefabDatabase).AsSingle();
        
        //Services...
        Container.Bind<SaveLoadManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerResources>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SavableObjectsManager>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<SavableObjectsManager>().FromComponentInHierarchy().AsCached();
        
        //Repository...
        Container.BindInterfacesTo<GameRepository>().FromNew().AsSingle().NonLazy();
        
        //SaveLoaders...
        Container.BindInterfacesTo<PlayerResourcesSaveLoader>().FromNew().AsCached();
        Container.BindInterfacesTo<SavableObjectsSaveLoader>().FromNew().AsCached();

        //?
        Container.Bind<SavableObject>().FromComponentsInHierarchy().AsCached();
        
        //Factory...
        Container.BindFactory<Transform, string, SavableObject, SavableObject.Factory>();
    }
}
