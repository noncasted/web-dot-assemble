using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Scenes.Operations.Logs;
using UnityEditor;

namespace Global.Scenes.Operations.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScenesFlowLogs))]
    public class ScenesFlowLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}