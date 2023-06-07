using System;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PlayerProgressPresenter : IPlayerProgressPresenter, IInitializable, IDisposable
    {
        public event Action<float, string> OnExperienceChanged;

        [Inject] private PlayerLevel playerLevel;

        public void Initialize()
        {
            playerLevel.OnExperienceChanged += ExperienceChanged;
            playerLevel.OnLevelUp += LevelUp;
        }

        public void Dispose()
        {
            playerLevel.OnExperienceChanged -= ExperienceChanged;
            playerLevel.OnLevelUp -= LevelUp;
        }

        private void LevelUp()
        {
           ExperienceChanged();
        }

        private void ExperienceChanged(int value = 0)
        {
            OnExperienceChanged?.Invoke(GetExpProgress(), GetExpProgressText());
        }

        public float GetExpProgress()
        {
            return (float)playerLevel.CurrentExperience / (float)playerLevel.RequiredExperience;
        }

        public string GetExpProgressText()
        {
            return $"XP: {playerLevel.CurrentExperience}/{playerLevel.RequiredExperience}";
        }
    }
}
