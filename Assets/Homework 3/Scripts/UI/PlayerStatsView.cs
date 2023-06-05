using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class PlayerStatsView : MonoBehaviour
    {
        [SerializeField] private PlayerStatView prefab;

        private List<PlayerStatView> statsViews = new List<PlayerStatView>();

        public void SetPlayerStats(IPlayerPopupPresenter.IPlayerStat[] stats)
        {
            foreach (var stat in stats)
            {
                CreateStatView(stat);
            }
        }

        private void CreateStatView(IPlayerPopupPresenter.IPlayerStat stat)
        {
            var statView = Instantiate(prefab, transform);
            statView.Construct(stat);
            statsViews.Add(statView);
        }

        public void AddStat(IPlayerPopupPresenter.IPlayerStat stat)
        {
            CreateStatView(stat);
        }

        public void RemoveStat(IPlayerPopupPresenter.IPlayerStat stat)
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