using Game.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace Lessons.Architecture.PM
{
    public class PlayerPopup : Popup
    {
        [Header("Views")] 
        [SerializeField] private TextMeshProUGUI nickname;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Image icon;
        [SerializeField] private ProgressBarView progressBar;
        [SerializeField] private PlayerStatsView playerStats;
        [SerializeField] private LevelUpButton levelUpButton;
        [SerializeField] private Button closeButton;

        [Inject] private IPlayerPopupPresenter presentationModel;

        [Button]
        protected override void OnShow()
        {
            SetUiData();
            ObserveChanges();
            BindButtons();

            presentationModel.Start();
        }

        private void BindButtons()
        {
            levelUpButton.AddListener(OnLevelUpClicked);
            closeButton.onClick.AddListener(OnCloseClicked);
        }

        private void SetUiData()
        {
            SetName(presentationModel.GetNickname());
            SetDescription(presentationModel.GetDescription());
            SetIcon(presentationModel.GetAvatar());
            SetLevel(presentationModel.GetLevel());
            SetExperience(
                presentationModel.GetExpProgress(),
                presentationModel.GetExpProgressText()
            );

            SetPlayerStats(presentationModel.GetPlayerStats());

            SetLevelUpButtonState(presentationModel.CanLevelUp());
        }

        private void SetLevelUpButtonState(bool canLevelUp)
        {
            var state = canLevelUp ? LevelUpButton.State.AVAILABLE : LevelUpButton.State.LOCKED;
            levelUpButton.SetState(state);
        }

        private void SetPlayerStats(IPlayerPopupPresenter.IPlayerStat[] stats)
        {
            playerStats.SetPlayerStats(stats);
        }

        private void ObserveChanges()
        {
            presentationModel.OnNameChanged += SetName;
            presentationModel.OnDescriptionChanged += SetDescription;
            presentationModel.OnIconChanged += SetIcon;

            presentationModel.OnLevelUp += SetLevel;
            presentationModel.OnExperienceChanged += SetExperience;
            presentationModel.OnChangeCanLevelUp += SetLevelUpButtonState;
            presentationModel.OnStatAdded += StatAdded;
            presentationModel.OnStatRemoved += StatRemoved;
        }

        private void StatRemoved(IPlayerPopupPresenter.IPlayerStat stat)
        {
            playerStats.RemoveStat(stat);
        }

        private void StatAdded(IPlayerPopupPresenter.IPlayerStat stat)
        {
            playerStats.AddStat(stat);
        }


        private void SetLevel(string text)
        {
            level.text = text;
        }

        private void SetExperience(float progress, string text)
        {
            progressBar.SetProgress(progress);
            progressBar.SetText(text);
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

        protected override void OnHide()
        {
            levelUpButton.RemoveListener(OnLevelUpClicked);
            closeButton.onClick.RemoveListener(OnCloseClicked);

            presentationModel.OnNameChanged -= SetName;
            presentationModel.OnDescriptionChanged -= SetDescription;
            presentationModel.OnIconChanged -= SetIcon;

            presentationModel.OnLevelUp += SetLevel;
            presentationModel.OnExperienceChanged += SetExperience;

            presentationModel.OnStatAdded -= StatAdded;
            presentationModel.OnStatRemoved -= StatRemoved;

            presentationModel.Stop();
        }

        private void OnCloseClicked()
        {
            RequestClose();
        }

        private void OnLevelUpClicked()
        {
            presentationModel.TryToLeveUp();
        }
    }
}