using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class CharacterInfo
    {
        public event Action<CharacterStat> OnStatAdded;
        public event Action<CharacterStat> OnStatRemoved;
    
        [ShowInInspector]
        private readonly HashSet<CharacterStat> stats;

        public CharacterInfo(IEnumerable<CharacterStat> _stats)
        {
            stats = _stats.ToHashSet();
        }
        
        [Button]
        public void AddStat(CharacterStat stat)
        {
            if (this.stats.Add(stat))
            {
                this.OnStatAdded?.Invoke(stat);
            }
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            if (this.stats.Remove(stat))
            {
                this.OnStatRemoved?.Invoke(stat);
            }
        }
        
        [Button]
        public void RemoveStat(string name)
        {
            foreach (var stat in stats)
            {
                if (stat.Name == name)
                {
                    if (stats.Remove(stat))
                    {
                        this.OnStatRemoved?.Invoke(stat);
                    }        
                    return;
                }
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in this.stats)
            {
                if (stat.Name == name)
                {
                    return stat;
                }
            }

            throw new Exception($"Stat {name} is not found!");
        }

        public CharacterStat[] GetStats()
        {
            return this.stats.ToArray();
        }
    }
}