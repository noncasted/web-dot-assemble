using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Services.UI.LoadingScreens.Logs
{
    [Serializable]
    public class LoadingScreenLogs : ReadOnlyDictionary<LoadingScreenLogType, bool>
    {
    }
}