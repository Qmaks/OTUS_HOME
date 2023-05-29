using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class SceneInstaller : MonoInstaller
    {
        [Header("Prefabs")] [SerializeField] private GameObject character;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject enemy;

        [Header("Parents")] [SerializeField] private Transform characterTransform;
        [SerializeField] private Transform bulletTransform;
        [SerializeField] private Transform enemyTransform;

        public override void InstallBindings()
        {
            BindCommonSystems();
            BindCharacterSystems();
            BindEnemySystems();
            BindBulletSystems();
        }

        private void BindCommonSystems()
        {
            Container.Bind<GameManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelBackground>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CoroutineRunner>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<LevelBounds>().FromNew().AsSingle().NonLazy();
            Container.Bind<LevelBoundSceneLinks>().FromComponentInHierarchy().AsSingle();
        }

        private void BindCharacterSystems()
        {
            Container.Bind<CharacterView>()
                .FromComponentInNewPrefab(character)
                .UnderTransform(characterTransform)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterMoveSystem>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterFireSystem>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterDeathSystem>().FromNew().AsSingle().NonLazy();
        }

        private void BindEnemySystems()
        {
            Container.Bind<EnemyPositions>().FromNew().AsSingle().NonLazy();
            Container.Bind<EnemyPositionSceneLinks>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyShootSystem>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemySpawnSystem>().FromNew().AsSingle().NonLazy();

            Container.BindMemoryPool<EnemyView, EnemyView.Pool>()
                .FromComponentInNewPrefab(enemy)
                .UnderTransform(enemyTransform);
        }

        private void BindBulletSystems()
        {
            Container.BindInterfacesAndSelfTo<BulletSpawnSystem>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletRemoveSystem>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletCollisionSystem>().FromNew().AsSingle().NonLazy();

            Container.Bind<BulletConfig>().FromScriptableObjectResource("Configs/PlayerBullet").AsSingle();

            Container.BindMemoryPool<Bullet, Bullet.Pool>()
                .FromComponentInNewPrefab(bullet)
                .UnderTransform(bulletTransform);
        }
    }
}