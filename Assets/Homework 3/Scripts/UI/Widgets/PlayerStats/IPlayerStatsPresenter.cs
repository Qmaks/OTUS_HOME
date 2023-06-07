using System;
using System.Collections.Generic;

namespace Lessons.Architecture.PM
{
    public interface IPlayerStatsPresenter
    {
        event Action<IStat> OnStatAdded;
        event Action<IStat> OnStatRemoved;
        
        public IEnumerable<IStat> GetPlayerStats();

        public interface IStat
        {
            public event Action<string> OnValueChanged;

            public string GetValue();
            string Name { get; }
        }
    }
}