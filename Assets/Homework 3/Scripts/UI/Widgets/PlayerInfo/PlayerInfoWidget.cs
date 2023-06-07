using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PlayerInfoWidget : Widget
    {
        [SerializeField] private TextMeshProUGUI nickname;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Image icon;

        [Inject] private IPlayerInfoPresenter presenter;
        
        public override void OnShow()
        {
            SetName(presenter.GetNickname());
            SetDescription(presenter.GetDescription());
            SetIcon(presenter.GetAvatar());
            SetLevel(presenter.GetLevel());
            
            presenter.OnNameChanged += SetName;
            presenter.OnDescriptionChanged += SetDescription;
            presenter.OnIconChanged += SetIcon;
            presenter.OnLevelUp += SetLevel;
        }

        public override void OnHide()
        {
            presenter.OnNameChanged -= SetName;
            presenter.OnDescriptionChanged -= SetDescription;
            presenter.OnIconChanged -= SetIcon;
            presenter.OnLevelUp -= SetLevel;
        }
        
        private void SetIcon(Sprite sprite)
        {
            icon.sprite = sprite;
        }

        private void SetDescription(string text)
        {
            description.text = text;
        }

        private void SetName(string text)
        {
            nickname.text = text;
        }
        
        private void SetLevel(string text)
        {
            level.text = text;
        }
    }
}