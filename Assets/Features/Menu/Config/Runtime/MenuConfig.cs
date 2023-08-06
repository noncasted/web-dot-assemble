using Common.Architecture.Local.ComposedSceneConfig;
using Common.Architecture.Local.Services.Abstract;
using Menu.Achievements.UI;
using Menu.Collections.UI;
using Menu.Common;
using Menu.Leaderboards.UI;
using Menu.Loop.Runtime;
using Menu.Main.UI;
using Menu.Quests.UI;
using Menu.Settings.UI;
using Menu.Shop.UI;
using Menu.StateMachine.Runtime;
using Menu.UiRoot.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Menu.Config.Runtime
{
    [InlineEditor] [CreateAssetMenu(fileName = "Level", menuName = MenuAssetsPaths.Root + "Scene")]
    public class MenuConfig : ComposedSceneAsset
    {
        [FoldoutGroup("UI")] [SerializeField] private AchievementsUIFactory _achievements;
        [FoldoutGroup("UI")] [SerializeField] private CollectionsUIFactory _collections;
        [FoldoutGroup("UI")] [SerializeField] private LeaderboardsUIFactory _leaderboards;
        [FoldoutGroup("UI")] [SerializeField] private MainUIFactory _main;
        [FoldoutGroup("UI")] [SerializeField] private QuestsUIFactory _quests;
        [FoldoutGroup("UI")] [SerializeField] private SettingsUIFactory _settings;
        [FoldoutGroup("UI")] [SerializeField] private ShopUIFactory _shop;
        
        [FoldoutGroup("System")] [SerializeField] private BaseUiRootFactory _uiRoot;
        [FoldoutGroup("System")] [SerializeField] private StateMachineFactory _stateMachine;
        [FoldoutGroup("System")] [SerializeField] private MenuLoopFactory _loop;
        
        [SerializeField] private MenuScope _scopePrefab;

        protected override ILocalServiceFactory[] GetFactories()
        {
            return new ILocalServiceFactory[]
            {
                _achievements,
                _collections,
                _leaderboards,
                _main,
                _quests,
                _settings,
                _shop,
                
                _stateMachine,
                _loop
            };
        }

        protected override ILocalServiceAsyncFactory[] GetAsyncFactories()
        {
            return new ILocalServiceAsyncFactory[]
            {
                _uiRoot,
            };
        }

        protected override LifetimeScope AssignScope()
        {
            return _scopePrefab;
        }
    }
}