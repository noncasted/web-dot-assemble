using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Cameras.CurrentCameras.Logs
{
    [Serializable]
    public class CurrentCameraLogs : ReadOnlyDictionary<CurrentCameraLogType, bool>
    {
    }
}