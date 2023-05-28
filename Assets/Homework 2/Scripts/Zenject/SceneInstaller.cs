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
        Container.BindInterfacesAndSelfTo<InputManager>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<LevelBackground>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CoroutineRunner>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelBounds>().FromComponentInHierarchy().AsSingle();
    }

    private void BindCharacterSystems()
    {
        Container.Bind<CharacterView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<CharacterMoveSystem>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CharacterFireSystem>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CharacterDeathSystem>().FromNew().AsSingle().NonLazy();
    }

    private void BindEnemySystems()
    {
        Container.Bind<EnemyPositions>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyPool>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemyShootSystem>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EnemySpawnSystem>().FromNew().AsSingle().NonLazy();

        Container.BindFactory<EnemyView, EnemyView.Factory>()
            .FromComponentInNewPrefab(enemy)
            .AsSingle();
    }

    private void BindBulletSystems()
    {
        Container.BindInterfacesAndSelfTo<BulletSpawnSystem>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<BulletRemoveSystem>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<BulletCollisionSystem>().FromNew().AsSingle().NonLazy();

        Container.Bind<BulletConfig>().FromScriptableObjectResource("Configs/PlayerBullet").AsSingle();

        Container.BindMemoryPool<Bullet, Bullet.Pool>()
            .FromComponentInNewPrefab(bullet)
            .UnderTransform(bulletTransform)
            .AsSingle();
    }
}