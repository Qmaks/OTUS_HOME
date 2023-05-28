using ShootEmUp;
using UnityEngine;
using Zenject;
using Bullet = ShootEmUp.Bullet;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject enemy;

    public override void InstallBindings()
    {
        BindCommonSystems();
        BindCharacterSystems();
        BindEnemySystems();
        BindBulletSystems();
    }

    private void BindCommonSystems()
    {
        Container.BindInterfacesAndSelfTo<InputManager>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<LevelBackground>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelBounds>().FromComponentInHierarchy().AsSingle();
    }

    private void BindCharacterSystems()
    {
        Container.Bind<CharacterView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CharacterFireSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CharacterMoveSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CharacterDeathSystem>().FromComponentInHierarchy().AsSingle();
    }

    private void BindEnemySystems()
    {
        Container.Bind<EnemyPositions>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyPool>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemySpawnSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyShootSystem>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<EnemyView, EnemyView.Factory>()
            .FromComponentInNewPrefab(enemy)
            .AsSingle();
    }

    private void BindBulletSystems()
    {
        Container.Bind<BulletSpawnSystem>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<BulletRemoveSystem>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<BulletCollisionSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletConfig>().FromScriptableObjectResource("Configs/PlayerBullet").AsSingle();

        Container.BindMemoryPool<Bullet, Bullet.Pool>()
            .FromComponentInNewPrefab(bullet)
            .UnderTransform(bulletTransform)
            .AsSingle();
    }
}