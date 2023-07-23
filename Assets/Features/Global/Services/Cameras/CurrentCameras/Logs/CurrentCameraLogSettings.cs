using Global.Services.Cameras.CurrentCameras.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Cameras.CurrentCameras.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.LogsName,
        menuName = CurrentCameraRoutes.LogsPath)]
    public class CurrentCameraLogSettings : LogSettings<CurrentCameraLogs, CurrentCameraLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}