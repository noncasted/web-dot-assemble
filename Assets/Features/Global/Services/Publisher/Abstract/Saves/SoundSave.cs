using System;
using Global.Services.Publisher.Yandex.DataStorages;

namespace Global.Services.Publisher.Abstract.Saves
{
    [Serializable]
    public class SoundSave : IStorageEntry
    {
        public string SaveKey => SavesPaths.Sounds;
        public event Action Changed;

        public bool IsMuted { get; private set; }

        public void CreateDefault()
        {
            IsMuted = false;
        }

        public void SwitchMute()
        {
            IsMuted = !IsMuted;

            Changed?.Invoke();
        }

        public string Serialize()
        {
            //var raw = JsonConvert.SerializeObject(_isMuted);

            return "raw";
        }

        public void Deserialize(string raw)
        {
            //_isMuted = JsonConvert.DeserializeObject<bool>(raw);
        }
    }
}