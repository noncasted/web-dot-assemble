using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Scenes.CurrentSceneHandlers.Logs
{
    [Serializable]
    public class CurrentSceneHandlerLogs : ReadOnlyDictionary<CurrentSceneHandlerLogType, bool>
    {
    }
}