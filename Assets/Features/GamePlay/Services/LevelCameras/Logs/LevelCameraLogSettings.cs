using GamePlay.Services.LevelCameras.Common;
using Global.Services.System.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Services.LevelCameras.Logs
{
    [CreateAssetMenu(fileName = LevelCameraRoutes.LogsName,
        menuName = LevelCameraRoutes.LogsPath)]
    public class LevelCameraLogSettings : LogSettings<LevelCameraLogs, LevelCameraLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}