using System;
using Global.Publisher.Abstract.DataStorages;

namespace Global.LevelConfigurations.Runtime
{
    public class LevelsSave : IStorageEntry
    {
        private int _passedIndex;

        public const string Key = "levels";

        public string SaveKey => Key;
        public int PassedIndex => _passedIndex;

        public event Action Changed;

        public void CreateDefault()
        {
            _passedIndex = 0;
        }

        public string Serialize()
        {
            return _passedIndex.ToString();
        }

        public void Deserialize(string raw)
        {
            _passedIndex = int.Parse(raw);
        }

        public void OnNext()
        {
            _passedIndex++;
            Changed?.Invoke();
        }
    }
}