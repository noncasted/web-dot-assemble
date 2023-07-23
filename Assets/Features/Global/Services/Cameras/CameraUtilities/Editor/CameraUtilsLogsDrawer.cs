using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.Cameras.CameraUtilities.Logs;
using UnityEditor;

namespace Global.Services.Cameras.CameraUtilities.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CameraUtilsLogs))]
    public class CameraUtilsLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}