using Global.Services.Scenes.ScenesFlow.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Scenes.ScenesFlow.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.LogsName,
        menuName = ScenesFlowRoutes.LogsPath)]
    public class ScenesFlowLogSettings : LogSettings<ScenesFlowLogs, ScenesFlowLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}