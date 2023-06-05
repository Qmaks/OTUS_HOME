using UnityEngine;
~using Zenject;

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
            UserInfo = testRepository.GetUserInfo();
            PlayerLevel = testRepository.GetPlayerLevel();
            CharacterInfo = testRepository.GetCharacterInfo();
            
            Container.Bind<IPlayerPopupPresenter>().To<PlayerPopupPresenter>().FromNew().AsSingle();
            Container.Bind<UserInfo>().FromInstance(UserInfo);
            Container.Bind<CharacterInfo>().FromInstance(CharacterInfo);
            Container.Bind<PlayerLevel>().FromInstance(PlayerLevel);
        }
    }
}
