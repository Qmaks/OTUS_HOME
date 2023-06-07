using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private UserInfo UserInfo;
        [SerializeField] private PlayerLevel PlayerLevel;
        [SerializeField] private CharacterInfo CharacterInfo;

        [SerializeField] private TestRepository testRepository;
        
        public override void InstallBindings()
        {
            BindModels();
            BindPresenters();
        }

        private void BindPresenters()
        {
            Container.BindInterfacesAndSelfTo<PlayerInfoPresenter>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerProgressPresenter>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerStatsPresenter>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelUpPresenter>().FromNew().AsSingle();
        }

        private void BindModels()
        {
            UserInfo = testRepository.GetUserInfo();
            PlayerLevel = testRepository.GetPlayerLevel();
            CharacterInfo = testRepository.GetCharacterInfo();

            Container.Bind<UserInfo>().FromInstance(UserInfo);
            Container.Bind<CharacterInfo>().FromInstance(CharacterInfo);
            Container.Bind<PlayerLevel>().FromInstance(PlayerLevel);
        }
    }
}
