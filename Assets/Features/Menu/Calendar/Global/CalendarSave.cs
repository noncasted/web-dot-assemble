using System;
using System.Collections.Generic;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Menu.Calendar.Global
{
    public class CalendarSave : IStorageEntry
    {
        public const string Key = "calendar";

        public HashSet<int> PassedDays;
        
        public string SaveKey => Key;
        
        public event Action Changed;
        
        public void CreateDefault()
        {
            PassedDays = new HashSet<int>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(PassedDays);
        }

        public void Deserialize(string raw)
        {
            PassedDays = JsonConvert.DeserializeObject<HashSet<int>>(raw);
        }

        public bool IsPassed(int id)
        {
            return PassedDays.Contains(id);
        }
    }
}