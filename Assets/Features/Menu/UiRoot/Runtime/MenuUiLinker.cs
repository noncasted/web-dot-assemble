using Menu.Achievements.UI;
using Menu.Collections.UI;
using Menu.Leaderboards.UI;
using Menu.Main.UI;
using Menu.Quests.UI;
using Menu.Settings.UI;
using Menu.Shop.UI;
using UnityEngine;

namespace Menu.UiRoot.Runtime
{
    [DisallowMultipleComponent]
    public class MenuUiLinker : MonoBehaviour
    {
        [SerializeField] private AchievementsView _achievements;
        [SerializeField] private AvatarCollectionsView _avatarCollections;
        [SerializeField] private LeaderboardsView _leaderboards;
        [SerializeField] private MainView _main;
        [SerializeField] private QuestsView _quests;
        [SerializeField] private SettingsView _settings;
        [SerializeField] private ShopView _shopView;

        public IAchievementsView Achievements => _achievements;
        public IAvatarCollectionsView AvatarCollections => _avatarCollections;
        public ILeaderboardsView Leaderboards => _leaderboards;
        public IMainView Main => _main;
        public IQuestsView Quests => _quests;
        public ISettingsView Settings => _settings;
        public IShopView ShopView => _shopView;
    }
}