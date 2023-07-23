using System.Runtime.InteropServices;

namespace Global.Services.Publisher.Yandex.Languages
{
    public class LanguageExternAPI : ILanguageAPI
    {
        [DllImport("__Internal")]
        private static extern string GetLang();

        public string GetLanguage_Internal()
        {
            return GetLang();
        }
    }
}