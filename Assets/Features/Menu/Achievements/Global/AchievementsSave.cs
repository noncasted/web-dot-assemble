using System;
using System.Collections.Generic;
using Global.Publisher.Abstract.DataStorages;
using Menu.Achievements.Definitions;
using Newtonsoft.Json;

namespace Menu.Achievements.Global
{
    public class AchievementsSave : IStorageEntry
    {
        public const string Key = "Achievements";
        
        private Dictionary<TargetAchievement, int> _entries;
        
        public string SaveKey => "Achievements";
        public event Action Changed;

        public IReadOnlyDictionary<TargetAchievement, int> Entries => _entries;

        public void Update(TargetAchievement type, int progress)
        {
            _entries[type] = progress;
            Changed?.Invoke();
        }
        
        public void CreateDefault()
        {
            _entries = new Dictionary<TargetAchievement, int>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_entries);
        }

        public void Deserialize(string raw)
        {
            _entries = JsonConvert.DeserializeObject<Dictionary<TargetAchievement, int>>(raw);
        }
    }
}