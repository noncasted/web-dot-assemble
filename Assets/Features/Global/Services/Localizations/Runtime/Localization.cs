using Global.Publisher.Abstract.Languages;
using Global.Setup.Service.Callbacks;

namespace Global.Localizations.Runtime
{
    public class Localization : IGlobalAwakeListener
    {
        public Localization(ILocalizationStorage storage, ISystemLanguageProvider systemLanguageProvider)
        {
            _storage = storage;
            _systemLanguageProvider = systemLanguageProvider;
        }

        private readonly ILocalizationStorage _storage;
        private readonly ISystemLanguageProvider _systemLanguageProvider;

        public void OnAwake()
        {
            var datas = _storage.GetDatas();
            var language = _systemLanguageProvider.GetLanguage();

            foreach (var data in datas)
                data.SelectLanguage(language);
        }
    }
}