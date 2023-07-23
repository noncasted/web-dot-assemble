using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.Scenes.CurrentSceneHandlers.Logs;
using UnityEditor;

namespace Global.Services.Scenes.CurrentSceneHandlers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentSceneHandlerLogs))]
    public class CurrentSceneHandlerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}