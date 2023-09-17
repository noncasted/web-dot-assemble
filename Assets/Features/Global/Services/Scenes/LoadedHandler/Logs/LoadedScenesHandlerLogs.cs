using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Scenes.LoadedHandler.Logs
{
    [Serializable]
    public class LoadedScenesHandlerLogs : ReadOnlyDictionary<LoadedScenesHandlerLogType, bool>
    {
    }
}