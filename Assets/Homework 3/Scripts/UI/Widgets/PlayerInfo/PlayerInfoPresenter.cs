using System;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PlayerInfoPresenter : IPlayerInfoPresenter,IInitializable,IDisposable
    {
        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;
        public event Action<string> OnLevelUp;
        
        [Inject] private UserInfo userInfo;
        [Inject] private PlayerLevel playerLevel;
        
        public void Initialize()
        {
            userInfo.OnNameChanged += NameChanged;
            userInfo.OnDescriptionChanged += DescriptionChanged;
            userInfo.OnIconChanged += IconChanged;
            playerLevel.OnLevelUp += LevelUp;
        }

        public void Dispose()
        {
            userInfo.OnNameChanged -= NameChanged;
            userInfo.OnDescriptionChanged -= DescriptionChanged;
            userInfo.OnIconChanged -= IconChanged;
            playerLevel.OnLevelUp -= LevelUp;
        }

        private void IconChanged(Sprite icon)
        {
            OnIconChanged?.Invoke(icon);
        }

        private void DescriptionChanged(string text)
        {
            OnDescriptionChanged?.Invoke(text);
        }

        private void NameChanged(string text)
        {
            OnNameChanged?.Invoke(text);
        }

        private void LevelUp()
        {
            OnLevelUp?.Invoke(GetLevel());
        }
        
        public string GetNickname()
        {
            return userInfo.Name;
        }

        public string GetLevel()
        {
            return $"Level : {playerLevel.CurrentLevel}";
        }

        public Sprite GetAvatar()
        {
            return userInfo.Icon;
        }

        public string GetDescription()
        {
            return userInfo.Description;
        }
    }
}