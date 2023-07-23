using Global.Services.System.Loggers.Runtime;
using Global.Services.System.MessageBrokers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.MessageBrokers.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = MessageBrokerRouter.LogsName,
        menuName = MessageBrokerRouter.LogsPath)]
    public class MessageBrokerLogSettings : LogSettings<MessageBrokerLogs, MessageBrokerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}