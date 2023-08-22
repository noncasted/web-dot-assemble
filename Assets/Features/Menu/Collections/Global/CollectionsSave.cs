using System;
using System.Collections.Generic;
using Global.Services.Publisher.Yandex.DataStorages;
using Newtonsoft.Json;

namespace Menu.Collections.Global
{
    public class CollectionsSave : IStorageEntry
    {
        private Dictionary<int, bool> _avatars;
        
        public event Action Changed;
        
        public string SaveKey => "Collections";

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