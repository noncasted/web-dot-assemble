using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Cameras.CameraUtilities.Logs
{
    [Serializable]
    public class CameraUtilsLogs : ReadOnlyDictionary<CameraUtilsLogType, bool>
    {
    }
}