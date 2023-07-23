using System.Collections.Generic;
using Global.Services.UI.Localizations.Texts;

namespace Global.Services.UI.Localizations.Runtime
{
    public interface ILocalizationStorage
    {
        IReadOnlyList<LanguageTextData> GetDatas();
    }
}