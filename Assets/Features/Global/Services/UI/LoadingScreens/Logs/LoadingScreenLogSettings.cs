using Global.Services.System.Loggers.Runtime;
using Global.Services.UI.LoadingScreens.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.UI.LoadingScreens.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = LoadingScreenRouter.LogsName,
        menuName = LoadingScreenRouter.LogsPath)]
    public class LoadingScreenLogSettings : LogSettings<LoadingScreenLogs, LoadingScreenLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}