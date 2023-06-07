using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PlayerStatsWidget : Widget
    {
        [SerializeField] private PlayerStats playerStats;
        
        [Inject] private IPlayerStatsPresenter presenter;

        public override void OnShow()
        {
            SetPlayerStats(presenter.GetPlayerStats());
            
            presenter.OnStatAdded += StatAdded;
            presenter.OnStatRemoved += StatRemoved;
        }

        public override void OnHide()
        {
            presenter.OnStatAdded -= StatAdded;
            presenter.OnStatRemoved -= StatRemoved;
        }

        private void StatRemoved(IPlayerStatsPresenter.IStat stat)
        {
            playerStats.RemoveStat(stat);
        }

        private void StatAdded(IPlayerStatsPresenter.IStat stat)
        {
            playerStats.AddStat(stat);
        }

        private void SetPlayerStats(IEnumerable<IPlayerStatsPresenter.IStat> stats)
        {
            playerStats.SetPlayerStats(stats);
        }
    }
}