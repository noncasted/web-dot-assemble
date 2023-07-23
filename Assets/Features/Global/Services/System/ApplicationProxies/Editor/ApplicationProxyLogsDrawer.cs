using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.System.ApplicationProxies.Logs;
using UnityEditor;

namespace Global.Services.System.ApplicationProxies.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ApplicationProxyLogs))]
    public class ApplicationProxyLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}