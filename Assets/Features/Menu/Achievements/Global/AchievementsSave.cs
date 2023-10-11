using System;
using System.Collections.Generic;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Menu.Achievements.Global
{
    public class AchievementsSave : IStorageEntry
    {
        public const string Key = "Achievements";
        
        private Dictionary<string, int> _entries;
        
        public string SaveKey => "Achievements";
        public event Action Changed;

        public IReadOnlyDictionary<string, int> Entries => _entries;

        public void Update(string key, int progress)
        {
            _entries[key] = progress;
            Changed?.Invoke();
        }
        
        public void CreateDefault()
        {
            _entries = new Dictionary<string, int>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_entries);
        }

        public void Deserialize(string raw)
        {
            _entries = JsonConvert.DeserializeObject<Dictionary<string, int>>(raw);
        }
    }
}