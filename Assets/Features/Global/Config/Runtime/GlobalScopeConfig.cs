﻿using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.UniversalAnimators.Updaters.Runtime;
using Global.Audio.Listener.Runtime;
using Global.Audio.Player.Runtime;
using Global.Cameras.CameraUtilities.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.Debugs.Console.Runtime;
using Global.GameLoops.Runtime;
using Global.Inputs.View.Runtime;
using Global.LevelConfigurations.Runtime;
using Global.Localizations.Runtime;
using Global.Publisher.Abstract.Bootstrap;
using Global.System.ApplicationProxies.Runtime;
using Global.System.DestroyHandlers.Runtime;
using Global.System.LoadedHandler.Runtime;
using Global.System.MessageBrokers.Runtime;
using Global.System.Objects.Factory;
using Global.System.Pauses.Runtime;
using Global.System.ResourcesCleaners.Runtime;
using Global.System.Updaters.Runtime;
using Global.UI.EventSystems.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Overlays.Runtime;
using Global.UI.UiStateMachines.Runtime;
using Internal.Services.Scenes.Data;
using Menu.Achievements.Global;
using Menu.Calendar.Global;
using Menu.Collections.Global;
using Menu.Leaderboards.Global;
using Menu.Quests.Global;
using Menu.Settings.Global;
using Menu.Shop.Global;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Global.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Global/Config")]
    public class GlobalScopeConfig : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("Level")] [SerializeField] private LevelConfigurationFactory _levelConfiguration;
        [FoldoutGroup("Audio")] [SerializeField] private SoundsPlayerFactory _soundsPlayer;
        [FoldoutGroup("Audio")] [SerializeField] private AudioListenerSwitcherFactory _audioSwitcher;
        [FoldoutGroup("Camera")] [SerializeField] private CameraUtilsFactory _cameraUtils;
        [FoldoutGroup("Camera")] [SerializeField] private CurrentCameraFactory _currentCamera;
        [FoldoutGroup("Camera")] [SerializeField] private GlobalCameraFactory _globalCamera;
        [FoldoutGroup("Debugs")] [SerializeField] private DebugConsoleFactory _debugConsole;
        [FoldoutGroup("Input")] [SerializeField] private InputViewFactory _inputView;
        [FoldoutGroup("Publisher")] [SerializeField] private PublisherSdkFactory _publisherSdk;
        [FoldoutGroup("Scenes")] [SerializeField] private LoadedScenesHandlerFactory _loadedScenesHandler;
        [FoldoutGroup("System")] [SerializeField] private GameLoopFactory _gameLoop;
        [FoldoutGroup("System")] [SerializeField] private ApplicationProxyFactory _applicationProxy;
        [FoldoutGroup("System")] [SerializeField] private MessageBrokerFactory _messageBroker;
        [FoldoutGroup("System")] [SerializeField] private PauseFactory _pause;
        [FoldoutGroup("System")] [SerializeField] private ResourcesCleanerFactory _resourcesCleaner;
        [FoldoutGroup("System")] [SerializeField] private UpdaterFactory _updater;
        [FoldoutGroup("System")] [SerializeField] private AnimatorsUpdaterFactory _animatorsUpdater;
        [FoldoutGroup("System")] [SerializeField] private DestroyHandlerFactory _destroyHandler;
        [FoldoutGroup("System")] [SerializeField] private ObjectsFactory _objects;
        [FoldoutGroup("UI")] [SerializeField] private LoadingScreenFactory _loadingScreen;
        [FoldoutGroup("UI")] [SerializeField] private LocalizationFactory _localization;
        [FoldoutGroup("UI")] [SerializeField] private OverlayAsset _overlay;
        [FoldoutGroup("UI")] [SerializeField] private UiStateMachineFactory _uiStateMachine;
        [FoldoutGroup("UI")] [SerializeField] private EventSystemFactory _eventSystem;
        [FoldoutGroup("Menu")] [SerializeField] private AchievementsServiceFactory _achievements;
        [FoldoutGroup("Menu")] [SerializeField] private CollectionsFactory _collections;
        [FoldoutGroup("Menu")] [SerializeField] private LeaderboardsFactory _leaderboards;
        [FoldoutGroup("Menu")] [SerializeField] private QuestsServiceFactory _questsService;
        [FoldoutGroup("Menu")] [SerializeField] private SettingsFactory _settings;
        [FoldoutGroup("Menu")] [SerializeField] private ShopFactory _shop;
        [FoldoutGroup("Menu")] [SerializeField] private CalendarFactory _calendar;

        [SerializeField] private GlobalScope _scope;
        [SerializeField] private SceneData _servicesScene;
        public LifetimeScope ScopePrefab => _scope;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();
        public IReadOnlyList<ICallbacksFactory> Callbacks => GetCallbacks();

        private IServiceFactory[] GetFactories()
        {
            return new IServiceFactory[]
            {
                _levelConfiguration,
                _applicationProxy,
                _cameraUtils,
                _currentCamera,
                _loadedScenesHandler,
                _globalCamera,
                _inputView,
                _resourcesCleaner,
                _updater,
                _animatorsUpdater,
                _debugConsole,
                _messageBroker,
                _uiStateMachine,
                _eventSystem,
                _soundsPlayer,
                _audioSwitcher,
                _localization,
                _pause,
                _destroyHandler,
                _objects,
                _achievements,
                _collections,
                _leaderboards,
                _questsService,
                _settings,
                _shop,
                _calendar,
                _publisherSdk,
                _loadingScreen,
                _overlay,
                _gameLoop
            };
        }

        private ICallbacksFactory[] GetCallbacks()
        {
            return new ICallbacksFactory[]
            {
                new DefaultCallbacksFactory()
            };
        }
    }
}