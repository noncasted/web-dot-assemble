using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Services.System.Updaters.Logs
{
    [Serializable]
    public class UpdaterLogs : ReadOnlyDictionary<UpdaterLogType, bool>
    {
    }
}