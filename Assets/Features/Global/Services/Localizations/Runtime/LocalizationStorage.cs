using System.Collections.Generic;
using System.Collections.ObjectModel;
using Global.Localizations.Common;
using Global.Localizations.Texts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Localizations.Runtime
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