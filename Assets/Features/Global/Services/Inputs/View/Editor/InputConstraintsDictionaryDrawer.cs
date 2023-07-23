using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Services.Inputs.Constranits.Storage;
using UnityEditor;

namespace Global.Services.Inputs.View.Editor
{
    [CustomPropertyDrawer(typeof(InputConstraintsDictionary))]
    public class InputConstraintsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}