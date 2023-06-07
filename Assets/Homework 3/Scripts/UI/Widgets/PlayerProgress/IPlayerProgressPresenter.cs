using System;

namespace Lessons.Architecture.PM
{
    public interface IPlayerProgressPresenter
    {
        event Action<float, string> OnExperienceChanged;

        float GetExpProgress();
        string GetExpProgressText();
    }
}