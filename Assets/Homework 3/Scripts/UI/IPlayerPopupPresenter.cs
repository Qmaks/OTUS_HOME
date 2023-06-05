using System;
using Lessons.Architecture.PM;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IPlayerPopupPresenter
    {
        event Action<string> OnNameChanged;
        event Action<string> OnDescriptionChanged;
        event Action<Sprite> OnIconChanged;
        event Action<string> OnLevelUp;
        event Action<bool> OnChangeCanLevelUp;
        event Action<float, string> OnExperienceChanged;
        event Action<IPlayerStat> OnStatAdded;
        event Action<IPlayerStat> OnStatRemoved;

        public IPlayerStat[] GetPlayerStats();

        public interface IPlayerStat
        {
            public event Action<int> OnValueChanged;
            string Name { get; }
            int Value { get; }
        }

        public string GetNickname();
        string GetLevel();
        Sprite GetAvatar();
        bool CanLevelUp();
        string GetDescription();
        float GetExpProgress();
        string GetExpProgressText();
        void Start();
        void Stop();
        void TryToLeveUp();
    }
}

