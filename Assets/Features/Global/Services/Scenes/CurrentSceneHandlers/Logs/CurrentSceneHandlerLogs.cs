using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Scenes.CurrentSceneHandlers.Logs
{
    [Serializable]
    public class CurrentSceneHandlerLogs : ReadOnlyDictionary<CurrentSceneHandlerLogType, bool>
    {
    }
}