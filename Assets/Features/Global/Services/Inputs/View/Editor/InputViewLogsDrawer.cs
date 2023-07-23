using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.Inputs.View.Logs;
using UnityEditor;

namespace Global.Services.Inputs.View.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(InputViewLogs))]
    public class InputViewLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}