using System;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class LevelUpButtonWidget : Widget
    {
        [SerializeField] private LevelUpButton levelUpButtonWidget;

        [Inject] private ILevelUpButtonPresenter presenter;

        public override void OnShow()
        {
            SetLevelUpButtonState(presenter.CanLevelUp());
            
            presenter.OnChangeCanLevelUp += SetLevelUpButtonState;
            levelUpButtonWidget.AddListener(OnLevelUpClicked);
        }

        public override void OnHide()
        {
            presenter.OnChangeCanLevelUp -= SetLevelUpButtonState;
            levelUpButtonWidget.RemoveListener(OnLevelUpClicked); 
        }

        private void SetLevelUpButtonState(bool canLevelUp)
        {
            var state = canLevelUp ? LevelUpButton.State.AVAILABLE : LevelUpButton.State.LOCKED;
            levelUpButtonWidget.SetState(state);
        }

        private void OnLevelUpClicked()
        {
            presenter.TryToLeveUp();
        }
    }
}
