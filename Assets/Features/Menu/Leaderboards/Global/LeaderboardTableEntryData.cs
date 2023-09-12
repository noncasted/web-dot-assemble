using Global.Localizations.Texts;
using Global.Publisher.Abstract.Leaderboards;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.Global
{
    [InlineEditor]
    public class LeaderboardTableEntryData : ScriptableObject, ILeaderboardLink
    {
        [SerializeField] private string _apiName;

        [SerializeField] private LanguageTextData _text;

        public string ApiName => _apiName;
        public LanguageTextData Text => _text;
        
        public string GetLeaderboardName()
        {
            return _apiName;
        }
    }
}