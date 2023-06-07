using System;
using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class PlayerStatView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stat;
        public string Name { get; private set; }

        private IPlayerStatsPresenter.IStat playerStat;
        
        public void Construct(IPlayerStatsPresenter.IStat _stat)
        {
            playerStat = _stat;
            
            Name = playerStat.Name;
            SetText(playerStat.GetValue());
            playerStat.OnValueChanged += SetText;
        }

        private void SetText(string value)
        {
            stat.text = value;
        }

        private void OnDestroy()
        {
            playerStat.OnValueChanged -= SetText;
        }
    }
}