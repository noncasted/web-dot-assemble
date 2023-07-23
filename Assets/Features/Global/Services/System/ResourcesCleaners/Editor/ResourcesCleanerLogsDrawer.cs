using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.System.ResourcesCleaners.Logs;
using UnityEditor;

namespace Global.Services.System.ResourcesCleaners.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ResourcesCleanerLogs))]
    public class ResourcesCleanerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}