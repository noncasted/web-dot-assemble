using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.System.Updaters.Logs;
using UnityEditor;

namespace Global.Services.System.Updaters.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UpdaterLogs))]
    public class UpdaterLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}