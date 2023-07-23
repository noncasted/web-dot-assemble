using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.Cameras.CurrentCameras.Logs;
using UnityEditor;

namespace Global.Services.Cameras.CurrentCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentCameraLogs))]
    public class CurrentCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}