using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Scenes.LoadedHandler.Logs;
using UnityEditor;

namespace Global.Scenes.LoadedHandler.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LoadedScenesHandlerLogs))]
    public class LoadedScenesHandlerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}