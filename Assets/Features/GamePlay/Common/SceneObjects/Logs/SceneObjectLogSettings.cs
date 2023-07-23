using GamePlay.Common.SceneObjects.Common;
using Global.Services.System.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Common.SceneObjects.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = SceneObjectsRoutes.LogsName,
        menuName = SceneObjectsRoutes.LogsPath)]
    public class SceneObjectLogSettings : LogSettings<SceneObjectLogs, SceneObjectLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}