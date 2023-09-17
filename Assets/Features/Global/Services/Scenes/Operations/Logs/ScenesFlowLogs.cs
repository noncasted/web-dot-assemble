using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Scenes.Operations.Logs
{
    [Serializable]
    public class ScenesFlowLogs : ReadOnlyDictionary<ScenesFlowLogType, bool>
    {
    }
}