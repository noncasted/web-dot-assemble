using System;
using System.Collections.Generic;
using System.Linq;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Menu.Leaderboards.Common;
using UnityEngine;

namespace Menu.Leaderboards.Global
{
    [CreateAssetMenu(fileName = LeaderboardsRoutes.EntriesName,
        menuName = LeaderboardsRoutes.EntriesPath)]
    public class LeaderboardsTableEntriesConfig : ScriptableObject
    {
        [SerializeField] [NestedScriptableObjectList] private List<LeaderboardTableEntryData> _entries;

        public LeaderboardTableEntryData First()
        {
            return _entries.First();
        }
        
        public LeaderboardTableEntryData Previous(LeaderboardTableEntryData current = null)
        {
            if (current == null)
                return _entries.First();

            for (var i = 0; i < _entries.Count; i++)
            {
                if (_entries[i] != current)
                    continue;

                if (i == 0)
                    return _entries[^1];

                return _entries[i - 1];
            }

            throw new NullReferenceException($"No next entry for {current.name} found");
        } 
        
        public LeaderboardTableEntryData Next(LeaderboardTableEntryData current = null)
        {
            if (current == null)
                return _entries.First();

            for (var i = 0; i < _entries.Count; i++)
            {
                if (_entries[i] != current)
                    continue;

                if (i == _entries.Count - 1)
                    return _entries[0];

                return _entries[i + 1];
            }

            throw new NullReferenceException($"No next entry for {current.name} found");
        }
    }
}