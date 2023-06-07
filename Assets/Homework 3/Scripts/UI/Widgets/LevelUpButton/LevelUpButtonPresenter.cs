using System;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class LevelUpPresenter : ILevelUpButtonPresenter, IInitializable, IDisposable
    {
        public event Action<bool> OnChangeCanLevelUp;

        [Inject] private PlayerLevel playerLevel;

        public void Initialize()
        {
            playerLevel.OnExperienceChanged += ExperienceChanged;
            playerLevel.OnLevelUp += LevelUp;
        }

        public void Dispose()
        {
            playerLevel.OnExperienceChanged -= ExperienceChanged;
        }

        private void ExperienceChanged(int obj)
        {
            OnChangeCanLevelUp?.Invoke(CanLevelUp());
        }
        
        private void LevelUp()
        {
            OnChangeCanLevelUp?.Invoke(CanLevelUp());
        }

        public void TryToLeveUp()
        {
            playerLevel.LevelUp();
        }

        public bool CanLevelUp()
        {
            return playerLevel.CanLevelUp();
        }
    }
}
