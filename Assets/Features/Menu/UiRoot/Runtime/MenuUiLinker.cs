using Menu.Achievements.UI;
using Menu.Collections.UI;
using Menu.Leaderboards.UI;
using Menu.Main.UI;
using Menu.Quests.UI;
using Menu.Settings.UI;
using Menu.Shop.UI;
using Menu.StateMachine.Runtime;
using UnityEngine;
using UnityEngine.Serialization;

namespace Menu.UiRoot.Runtime
{
    [DisallowMultipleComponent]
    public class MenuUiLinker : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        
        [SerializeField] private AchievementsView _achievements;
        [SerializeField] private CollectionsView _collections;
        [SerializeField] private LeaderboardsView _leaderboards;
        [SerializeField] private MainView _main;
        [SerializeField] private QuestsView _quests;
        [SerializeField] private SettingsView _settings;
        [SerializeField] private ShopView _shopView;
        [SerializeField] private TabTransitionsRegistry _tabTransitionPoints;

        public Transform Root => _root;
        
        public IAchievementsView Achievements => _achievements;
        public ICollectionsView Collections => _collections;
        public ILeaderboardsView Leaderboards => _leaderboards;
        public IMainView Main => _main;
        public IQuestsView Quests => _quests;
        public ISettingsView Settings => _settings;
        public IShopView ShopView => _shopView;
        public ITransitionPointsRegistry TabTransitionPoints => _tabTransitionPoints;
    }
}