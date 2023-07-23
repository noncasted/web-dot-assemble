using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.UI.Localizations.Texts
{
    [InlineEditor]
    public class LanguageEntry : ScriptableObject
    {
        [SerializeField] private string _text;

        public string Text => _text;
    }
}