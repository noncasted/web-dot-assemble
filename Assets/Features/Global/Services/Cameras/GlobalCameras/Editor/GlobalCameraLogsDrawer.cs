using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.Cameras.GlobalCameras.Logs;
using UnityEditor;

namespace Global.Services.Cameras.GlobalCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(GlobalCameraLogs))]
    public class GlobalCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}