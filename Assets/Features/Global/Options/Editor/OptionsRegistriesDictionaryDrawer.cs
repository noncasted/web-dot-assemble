using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.Options.Runtime;
using UnityEditor;

namespace Global.Options.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(OptionsRegistriesDictionary))]
    public class OptionsRegistriesDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}