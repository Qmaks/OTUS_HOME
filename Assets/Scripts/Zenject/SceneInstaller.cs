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
        Container.Bind<CharacterView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelBounds>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyPositions>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletConfig>().FromScriptableObjectResource("Configs/PlayerBullet").AsSingle();
        
        Container.BindMemoryPool<Bullet, Bullet.Pool>()
            .FromComponentInNewPrefab(bullet)
            .UnderTransform(bulletTransform)
            .AsSingle();
    }
}