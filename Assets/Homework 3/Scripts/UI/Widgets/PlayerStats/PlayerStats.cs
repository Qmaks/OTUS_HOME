using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private PlayerStatView prefab;

        private List<PlayerStatView> statsViews = new List<PlayerStatView>();

        public void SetPlayerStats(IEnumerable<IPlayerStatsPresenter.IStat> stats)
        {
            foreach (var stat in stats)
            {
                CreateStatView(stat);
            }
        }
        
        private void CreateStatView(IPlayerStatsPresenter.IStat stat)
        {
            var statView = Instantiate(prefab, transform);
            statView.Construct(stat);
            statsViews.Add(statView);
        }

        public void AddStat(IPlayerStatsPresenter.IStat stat)
        {
            CreateStatView(stat);
        }

        public void RemoveStat(IPlayerStatsPresenter.IStat stat)
        {
            foreach (var view in statsViews)
            {
                if (view.Name == stat.Name)
                {
                    Destroy(view.gameObject);
                    return;
                }
            }
        }
    }
}