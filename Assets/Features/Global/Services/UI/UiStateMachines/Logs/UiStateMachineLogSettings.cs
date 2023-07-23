using Global.Services.System.Loggers.Runtime;
using Global.Services.UI.UiStateMachines.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.UI.UiStateMachines.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = UiStateMachineRouter.LogsName,
        menuName = UiStateMachineRouter.LogsPath)]
    public class UiStateMachineLogSettings : LogSettings<UiStateMachineLogs, UiStateMachineLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}