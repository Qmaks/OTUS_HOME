using Homeworks_5.Shooter.Scripts;
using Homeworks_5.Shooter.Scripts.Bullet;
using Homeworks_5.Shooter.Scripts.UI;
using Homeworks_5.Shooter.Scripts.Zombie;
using UnityEngine;
using Zenject;

public class Scene5Installer : MonoInstaller
{
    [Header("Game Objects")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject zombiePrefab;

    [Header("UI")]
    [SerializeField] private TextView bulletView;
    [SerializeField] private TextView hpView;
    [SerializeField] private TextView killedView;
    [SerializeField] private FinishGameView finishGame;

    public override void InstallBindings()
    {
        BindController();
        BindUI();
        BindHero();
        BindBullets();
        BindZombies();
        BindScene();
    }

    private void BindController()
    {
        Container.BindInterfacesTo<GameController>().FromNew().AsSingle().NonLazy();
    }

    private void BindUI()
    {
        Container.BindInterfacesAndSelfTo<BulletViewPresenter>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<KilledViewPresenter>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<HpViewPresenter>().FromNew().AsSingle().NonLazy();


        Container.Bind<TextView>()
            .WithId(typeof(BulletViewPresenter))
            .FromInstance(bulletView);

        Container.Bind<TextView>()
            .WithId(typeof(HpViewPresenter))
            .FromInstance(hpView);

        Container.Bind<TextView>()
            .WithId( typeof(KilledViewPresenter))
            .FromInstance(killedView);
        
        Container.Bind<FinishGameView>().FromInstance(finishGame).AsSingle();
    }

    private void BindHero()
    {
        Container.Bind<HeroEntity>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
        
        Container.BindInterfacesTo<MoveController>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesTo<ShootController>().FromNew().AsSingle().NonLazy();
    }

    private void BindScene()
    {
        Container.Bind<SpawnPointsController>().FromComponentInHierarchy().AsSingle();
    }

    private void BindZombies()
    {
         Container.BindInterfacesAndSelfTo<ZombieSpawner>().FromNew().AsSingle();
         Container.BindInterfacesAndSelfTo<ZombieDestroyer>().FromNew().AsSingle();
        
        Container.BindFactory<ZombieEntity, ZombieFactory>()
            .FromComponentInNewPrefab(zombiePrefab)
            .AsSingle();
    }

    private void BindBullets()
    {
        Container.BindInterfacesAndSelfTo<BulletSpawner>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<BulletDestroyer>().FromNew().AsSingle();
        
        Container.BindFactory<BulletEntity, BulletFactory>()
            .FromComponentInNewPrefab(bulletPrefab);
    }
}
