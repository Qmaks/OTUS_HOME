using ShootEmUp;
using UnityEngine;
using Zenject;
using Bullet = ShootEmUp.Bullet;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject bullet;

    public override void InstallBindings()
    {
      
        Container.Bind<InputManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelBounds>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<CharacterView>().FromComponentInHierarchy().AsSingle();
        
        BindEnemySystems();
        BindBulletSystems();


        Container.BindMemoryPool<Bullet, Bullet.Pool>()
            .FromComponentInNewPrefab(bullet)
            .UnderTransform(bulletTransform)
            .AsSingle();
    }

    private void BindEnemySystems()
    {
        Container.Bind<EnemyPositions>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyPool>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemySpawnSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyShootSystem>().FromComponentInHierarchy().AsSingle();
    }

    private void BindBulletSystems()
    {
        Container.Bind<BulletSpawnSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletRemoveSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletCollisionSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletConfig>().FromScriptableObjectResource("Configs/PlayerBullet").AsSingle();
    }
}