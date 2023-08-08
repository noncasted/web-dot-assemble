using System;
using System.Collections.Generic;
using Global.Services.Publisher.Yandex.DataStorages;
using Menu.Achievements.Definitions;
using Newtonsoft.Json;

namespace Menu.Achievements.Global
{
    public class AchievementsSave : IStorageEntry
    {
        private Dictionary<AchievementType, int> _entries;
        
        public string Key => "Achievements";
        public event Action Changed;

        public IReadOnlyDictionary<AchievementType, int> Entries => _entries;

        public void Update(AchievementType type, int progress)
        {
            _entries[type] = progress;
        }
        
        public void CreateDefault()
        {
            _entries = new Dictionary<AchievementType, int>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_entries);
        }

        public void Deserialize(string raw)
        {
            _entries = JsonConvert.DeserializeObject<Dictionary<AchievementType, int>>(raw);
        }
    }
}