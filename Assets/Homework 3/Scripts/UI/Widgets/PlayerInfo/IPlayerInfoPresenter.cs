using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IPlayerInfoPresenter
    {
        event Action<string> OnNameChanged;
        event Action<string> OnDescriptionChanged;
        event Action<Sprite> OnIconChanged;
        event Action<string> OnLevelUp;
        
        public string GetNickname();
        string GetLevel();
        Sprite GetAvatar();
        string GetDescription();
    }
}