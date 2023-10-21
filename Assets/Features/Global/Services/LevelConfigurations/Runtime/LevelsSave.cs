using System;
using System.Collections.Generic;
using GamePlay.Level.Dots.Definitions;
using Global.Publisher.Abstract.DataStorages;
using Newtonsoft.Json;

namespace Global.LevelConfigurations.Runtime
{
    [Serializable]
    public class LevelsSave : IStorageEntry
    {
        private LevelSavePayload _value;
        public const string Key = "levels";

        public string SaveKey => Key;
        public int PassedIndex => _value.PassedIndex;
        public IReadOnlyList<int> SelectedDots => _value.SelectedDots;

        public event Action Changed;

        public void CreateDefault()
        {
            _value = new LevelSavePayload();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(_value);
        }

        public void Deserialize(string raw)
        {
            _value = JsonConvert.DeserializeObject<LevelSavePayload>(raw);
        }

        public void OnNext()
        {
            _value.PassedIndex++;
            Changed?.Invoke();
        }

        public void UpdateSelectedDots(IReadOnlyList<IDotDefinition> selectedDots)
        {
            var list = new List<int>();

            foreach (var dot in selectedDots)
                list.Add(dot.Id);
            
            _value.SelectedDots = list;
            Changed?.Invoke();
        }
    }

    [Serializable]
    public class LevelSavePayload
    {
        public int PassedIndex = 0;
        public IReadOnlyList<int> SelectedDots = new List<int>();
    }
}