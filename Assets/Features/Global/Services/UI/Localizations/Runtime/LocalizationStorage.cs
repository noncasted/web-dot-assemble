using System.Collections.Generic;
using System.Collections.ObjectModel;
using Global.Services.UI.Localizations.Common;
using Global.Services.UI.Localizations.Texts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.UI.Localizations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LocalizationRoutes.StorageName, menuName = LocalizationRoutes.StoragePath)]
    public class LocalizationStorage : ScriptableObject, ILocalizationStorage
    {
        [SerializeField] private LanguageTextData[] _datas;

        public IReadOnlyList<LanguageTextData> GetDatas()
        {
            var result = new ReadOnlyCollection<LanguageTextData>(_datas);

            return result;
        }
    }
}