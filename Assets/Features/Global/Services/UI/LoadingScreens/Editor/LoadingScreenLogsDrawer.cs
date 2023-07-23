using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.UI.LoadingScreens.Logs;
using UnityEditor;

namespace Global.Services.UI.LoadingScreens.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LoadingScreenLogs))]
    public class LoadingScreenLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}