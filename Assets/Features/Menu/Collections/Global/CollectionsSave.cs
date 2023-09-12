using System;
using System.Collections.Generic;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Menu.Collections.Global
{
    public class CollectionsSave : IStorageEntry
    {
        public const string Key = "collections";
        
        private Dictionary<string, bool> _avatars;
        
        public event Action Changed;
        
        public string SaveKey => Key;

        public IReadOnlyDictionary<string, bool> Avatars => _avatars;

        public void CreateDefault()
        {
            _avatars = new Dictionary<string, bool>();
        }

        public void OnUnlocked(string id)
        {
            _avatars[id] = true;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_avatars);
        }

        public void Deserialize(string raw)
        {
            _avatars = JsonConvert.DeserializeObject<Dictionary<string, bool>>(raw);
        }
    }
}