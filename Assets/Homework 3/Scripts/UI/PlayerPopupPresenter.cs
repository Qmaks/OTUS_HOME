using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PlayerPopupPresenter : IPlayerPopupPresenter
    {
        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;
        public event Action<string> OnLevelUp;
        public event Action<float,string> OnExperienceChanged;
        public event Action<bool> OnChangeCanLevelUp; 
        public event Action<IPlayerPopupPresenter.IPlayerStat> OnStatAdded;
        public event Action<IPlayerPopupPresenter.IPlayerStat> OnStatRemoved;

        [Inject] private UserInfo userInfo;
        [Inject] private PlayerLevel playerLevel;
        [Inject] private CharacterInfo characterInfo;

        private List<IPlayerPopupPresenter.IPlayerStat> playerStats; 
        
        public void Start()
        {
            userInfo.OnNameChanged += OnNameChanged;
            userInfo.OnDescriptionChanged += OnDescriptionChanged;
            userInfo.OnIconChanged += OnIconChanged;

            playerLevel.OnLevelUp += LevelUp;
            playerLevel.OnExperienceChanged += ExperienceChanged;
            
            characterInfo.OnStatAdded += StatAdded;
            characterInfo.OnStatRemoved += StatRemoved;
        }

        private void StatRemoved(CharacterStat stat)
        {
            foreach (var playerStat in playerStats)
            {
                if (playerStat.Name == stat.Name)
                {
                    OnStatRemoved?.Invoke(playerStat);
                    playerStats.Remove(playerStat);
                    return;
                }
            }
        }

        private void StatAdded(CharacterStat stat)
        {
            var presenter = new PlayerPopupPresenterStat(stat.Name, stat.Value);
            stat.OnValueChanged += presenter.ChangeValue;
            playerStats.Add(presenter);
            OnStatAdded?.Invoke(presenter);
        }

        public void Stop()
        {
            userInfo.OnNameChanged -= OnNameChanged;
            userInfo.OnDescriptionChanged -= OnDescriptionChanged;
            userInfo.OnIconChanged -= OnIconChanged;
            
            playerLevel.OnLevelUp -= LevelUp;
            playerLevel.OnExperienceChanged -= ExperienceChanged;
            
            characterInfo.OnStatAdded -= StatAdded;
            characterInfo.OnStatRemoved -= StatRemoved;
        }

        public void TryToLeveUp()
        {
            playerLevel.LevelUp();
        }

        private void LevelUp()
        {
            OnLevelUp?.Invoke(GetLevel());
            ExperienceChanged(0);
        }

        private void ExperienceChanged(int obj)
        {
            OnExperienceChanged?.Invoke(GetExpProgress(),GetExpProgressText());
            OnChangeCanLevelUp?.Invoke(CanLevelUp());
        }

        public IPlayerPopupPresenter.IPlayerStat[] GetPlayerStats()
        {
            playerStats = new List<IPlayerPopupPresenter.IPlayerStat>();

            foreach (var stat in characterInfo.GetStats())
            {
                var presenter = new PlayerPopupPresenterStat(stat.Name, stat.Value);
                stat.OnValueChanged += presenter.ChangeValue;
                playerStats.Add(presenter);
            }
            
            return playerStats.ToArray();
        }

        public string GetNickname()
        {
            return userInfo.Name;
        }

        public string GetDescription()
        {
            return userInfo.Description;
        }

        public Sprite GetAvatar()
        {
            return userInfo.Icon;
        }

        public string GetLevel()
        {
            return $"Level : {playerLevel.CurrentLevel}";
        }

        public bool CanLevelUp()
        {
            return playerLevel.CanLevelUp();
        }

        public float GetExpProgress()
        {
            return (float)playerLevel.CurrentExperience/(float)playerLevel.RequiredExperience;
        }

        public string GetExpProgressText()
        {
            return $"XP: {playerLevel.CurrentExperience}/{playerLevel.RequiredExperience}";
        }

        private sealed class PlayerPopupPresenterStat : IPlayerPopupPresenter.IPlayerStat
        {
            public PlayerPopupPresenterStat(string name, int value)
            {
                Name = name;
                Value = value;
            }

            public event Action<int> OnValueChanged;

            public void ChangeValue(int value)
            {
                OnValueChanged?.Invoke(value);
            }
            
            public string Name { get; }
            public int Value { get; }
        }
    }
}