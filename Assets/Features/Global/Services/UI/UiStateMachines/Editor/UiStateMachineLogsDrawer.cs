using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.UI.UiStateMachines.Logs;
using UnityEditor;

namespace Global.Services.UI.UiStateMachines.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UiStateMachineLogs))]
    public class UiStateMachineLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}