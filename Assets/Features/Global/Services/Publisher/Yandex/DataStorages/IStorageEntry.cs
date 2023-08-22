using System;

namespace Global.Services.Publisher.Yandex.DataStorages
{
    public interface IStorageEntry
    {
        string SaveKey { get; }
        event Action Changed;

        void CreateDefault();
        string Serialize();
        void Deserialize(string raw);
    }
}