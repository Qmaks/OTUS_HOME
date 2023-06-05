using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class PlayerStatView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stat;
        public string Name { get; private set; }
        public int Value { get; private set; }

        public void Construct(IPlayerPopupPresenter.IPlayerStat playerStat)
        {
            Name = playerStat.Name;
            Value = playerStat.Value;
            playerStat.OnValueChanged += ChangeStatValue;
            SetText();
        }

        private void ChangeStatValue(int value)
        {
            Value = value;
            SetText();
        }

        private void SetText()
        {
            stat.text = $"{Name} : {Value}";
        }
    }
}