using System;

namespace Lessons.Architecture.PM
{
   public interface ILevelUpButtonPresenter
    {
        event Action<bool> OnChangeCanLevelUp;

        void TryToLeveUp();
        bool CanLevelUp();
    }
}