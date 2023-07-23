using System;

namespace Global.Services.Publisher.Yandex.DataStorages
{
    public interface IStorageEntry
    {
        string Key { get; }
        event Action Changed;

        void CreateDefault();
        string Serialize();
        void Deserialize(string raw);
    }
}