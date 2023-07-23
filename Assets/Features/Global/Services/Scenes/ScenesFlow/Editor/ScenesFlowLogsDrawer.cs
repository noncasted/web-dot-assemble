using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.Scenes.ScenesFlow.Logs;
using UnityEditor;

namespace Global.Services.Scenes.ScenesFlow.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScenesFlowLogs))]
    public class ScenesFlowLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}