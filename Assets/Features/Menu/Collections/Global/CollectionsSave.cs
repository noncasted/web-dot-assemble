using System;
using System.Collections.Generic;
using Global.Publisher.Yandex.DataStorages;
using Newtonsoft.Json;

namespace Menu.Collections.Global
{
    public class CollectionsSave : IStorageEntry
    {
        public const string Key = "collections";
        
        private Dictionary<int, bool> _avatars;
        
        public event Action Changed;
        
        public string SaveKey => Key;

        public IReadOnlyDictionary<int, bool> Avatars => _avatars;

        public void CreateDefault()
        {
            _avatars = new Dictionary<int, bool>();
        }

        public void OnUnlocked(int id)
        {
            _avatars[id] = true;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_avatars);
        }

        public void Deserialize(string raw)
        {
            _avatars = JsonConvert.DeserializeObject<Dictionary<int, bool>>(raw);
        }
    }
}