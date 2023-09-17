using System;
using System.Collections.Generic;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;
using UnityEngine;

namespace Menu.Calendar.Global
{
    public class CalendarSave : IStorageEntry
    {
        public const string Key = "calendar";

        public List<int> PassedDays;
        
        public string SaveKey => Key;
        
        public event Action Changed;
        
        public void CreateDefault()
        {
            PassedDays = new List<int>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(PassedDays);
        }

        public void Deserialize(string raw)
        {
            try
            {
                PassedDays = JsonConvert.DeserializeObject<List<int>>(raw);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        public bool IsPassed(int id)
        {
            return PassedDays.Contains(id);
        }
    }
}