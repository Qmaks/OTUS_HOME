using System;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PlayerProgressWidget : Widget
    {
        [SerializeField] private ProgressBar progressBar;

        [Inject] private IPlayerProgressPresenter presenter;

        public override void OnShow()
        {
            SetExperience(presenter.GetExpProgress(), presenter.GetExpProgressText());
            
            presenter.OnExperienceChanged += SetExperience;
        }

        public override void OnHide()
        {
            presenter.OnExperienceChanged -= SetExperience;
        }

        private void SetExperience(float progress, string text)
        {
            progressBar.SetProgress(progress);
            progressBar.SetText(text);
        }
    }
}
