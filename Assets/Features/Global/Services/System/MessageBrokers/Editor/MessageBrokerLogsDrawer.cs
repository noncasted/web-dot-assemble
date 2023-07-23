using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.System.MessageBrokers.Logs;
using UnityEditor;

namespace Global.Services.System.MessageBrokers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(MessageBrokerLogs))]
    public class MessageBrokerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}