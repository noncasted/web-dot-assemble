﻿using Global.Services.Publisher.Abstract.Languages;
using Global.Services.Setup.Service.Callbacks;

namespace Global.Services.UI.Localizations.Runtime
{
    public class Localization : IGlobalAwakeListener
    {
        public Localization(ILocalizationStorage storage, ILanguageProvider languageProvider)
        {
            _storage = storage;
            _languageProvider = languageProvider;
        }

        private readonly ILocalizationStorage _storage;
        private readonly ILanguageProvider _languageProvider;

        public void OnAwake()
        {
            var datas = _storage.GetDatas();
            var language = _languageProvider.GetLanguage();

            foreach (var data in datas)
                data.SelectLanguage(language);
        }
    }
}