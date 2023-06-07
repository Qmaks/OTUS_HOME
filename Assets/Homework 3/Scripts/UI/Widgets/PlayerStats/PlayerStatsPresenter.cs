using System;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class PlayerStatsPresenter : IPlayerStatsPresenter, IInitializable,IDisposable
    {
        public event Action<IPlayerStatsPresenter.IStat> OnStatAdded;
        public event Action<IPlayerStatsPresenter.IStat> OnStatRemoved;

        [Inject] private CharacterInfo characterInfo;
        
        private List<IPlayerStatsPresenter.IStat> playerStats; 
        
        public void Initialize()
        {
            characterInfo.OnStatAdded += StatAdded;
            characterInfo.OnStatRemoved += StatRemoved;
            
            InitStats();
        }

        public void Dispose()
        {
            characterInfo.OnStatAdded -= StatAdded;
            characterInfo.OnStatRemoved -= StatRemoved;
        }

        public IEnumerable<IPlayerStatsPresenter.IStat> GetPlayerStats() => playerStats;

        private void InitStats()
        {
            playerStats = new List<IPlayerStatsPresenter.IStat>();

            foreach (var stat in characterInfo.GetStats())
            {
                var presenter = new Stat(stat);
                playerStats.Add(presenter);
            }
        }

        private void StatRemoved(CharacterStat stat)
        {
            foreach (var playerStat in playerStats)
            {
                if (playerStat.Name == stat.Name)
                {
                    OnStatRemoved?.Invoke(playerStat);
                    playerStats.Remove(playerStat);
                    return;
                }
            }
        }

        private void StatAdded(CharacterStat stat)
        {
            var presenter = new Stat(stat);
            playerStats.Add(presenter);
            OnStatAdded?.Invoke(presenter);
        }

        private sealed class Stat : IPlayerStatsPresenter.IStat, IDisposable
        {
            public event Action<string> OnValueChanged;
            public string Name { get; }

            private CharacterStat stat;

            public Stat(CharacterStat _stat)
            {
                stat = _stat;
                Name = stat.Name;
                stat.OnValueChanged += ChangeValue;
            }

            public void ChangeValue(int value)
            {
                OnValueChanged?.Invoke(GetValue());
            }

            public string GetValue()
            {
                return $"{stat.Name} : {stat.Value}";
            }

            public void Dispose()
            {
                stat.OnValueChanged -= ChangeValue;
            }
        }
    }
}