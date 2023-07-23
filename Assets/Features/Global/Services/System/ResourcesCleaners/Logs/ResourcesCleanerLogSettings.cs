using Global.Services.System.Loggers.Runtime;
using Global.Services.System.ResourcesCleaners.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.ResourcesCleaners.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ResourcesCleanerRouter.LogsName,
        menuName = ResourcesCleanerRouter.LogsPath)]
    public class ResourcesCleanerLogSettings : LogSettings<ResourcesCleanerLogs, ResourcesCleanerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}