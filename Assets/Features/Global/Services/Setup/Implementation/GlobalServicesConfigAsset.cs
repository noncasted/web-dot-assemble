﻿using Common.UniversalAnimators.Updaters.Runtime;
using Global.Services.Audio.Listener.Runtime;
using Global.Services.Audio.Player.Runtime;
using Global.Services.Cameras.CameraUtilities.Runtime;
using Global.Services.Cameras.CurrentCameras.Runtime;
using Global.Services.Cameras.GlobalCameras.Runtime;
using Global.Services.Debugs.Console.Runtime;
using Global.Services.Inputs.View.Runtime;
using Global.Services.Publisher.Abstract.Bootstrap;
using Global.Services.Scenes.CurrentSceneHandlers.Runtime;
using Global.Services.Scenes.ScenesFlow.Runtime;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Service;
using Global.Services.System.ApplicationProxies.Runtime;
using Global.Services.System.DestroyHandlers.Runtime;
using Global.Services.System.Loggers.Runtime;
using Global.Services.System.MessageBrokers.Runtime;
using Global.Services.System.Pauses.Runtime;
using Global.Services.System.ResourcesCleaners.Runtime;
using Global.Services.System.Updaters.Runtime;
using Global.Services.UI.EventSystems.Runtime;
using Global.Services.UI.LoadingScreens.Runtime;
using Global.Services.UI.Overlays.Runtime;
using Global.Services.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using LocalizationAsset = Global.Services.UI.Localizations.Runtime.LocalizationAsset;

namespace Global.Services.Setup.Implementation
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Global/Config")]
    public class GlobalServicesConfigAsset : GlobalServicesConfig
    {
        [FoldoutGroup("Audio")] [SerializeField]
        private SoundsPlayerAsset _soundsPlayer;
        [FoldoutGroup("Audio")] [SerializeField]
        private AudioListenerSwitcherFactory _audioSwitcher;

        [FoldoutGroup("Camera")] [SerializeField]
        private CameraUtilsAsset _cameraUtils;
        [FoldoutGroup("Camera")] [SerializeField]
        private CurrentCameraAsset _currentCamera;
        [FoldoutGroup("Camera")] [SerializeField]
        private GlobalCameraAsset _globalCamera;

        [FoldoutGroup("Debugs")] [SerializeField]
        private DebugConsoleAsset _debugConsole;

        [FoldoutGroup("Input")] [SerializeField]
        private InputViewFactory _inputView;

        [FoldoutGroup("Publisher")] [SerializeField]
        private PublisherSdkAsset _publisherSdk;

        [FoldoutGroup("Scenes")] [SerializeField]
        private CurrentSceneHandlerAsset _currentSceneHandler;
        [FoldoutGroup("Scenes")] [SerializeField]
        private ScenesFlowAsset _scenesFlow;

        [FoldoutGroup("System")] [SerializeField]
        private ApplicationProxyAsset _applicationProxy;
        [FoldoutGroup("System")] [SerializeField]
        private LoggerAsset _logger;
        [FoldoutGroup("System")] [SerializeField]
        private MessageBrokerAsset _messageBroker;
        [FoldoutGroup("System")] [SerializeField]
        private PauseAsset _pause;
        [FoldoutGroup("System")] [SerializeField]
        private ResourcesCleanerAsset _resourcesCleaner;
        [FoldoutGroup("System")] [SerializeField]
        private UpdaterAsset _updater;
        [FoldoutGroup("System")] [SerializeField]
        private AnimatorsUpdaterFactory _animatorsUpdater;
        [FoldoutGroup("System")] [SerializeField]
        private DestroyHandlerFactory _destroyHandler;

        [FoldoutGroup("UI")] [SerializeField] private LoadingScreenAsset _loadingScreen;
        [FoldoutGroup("UI")] [SerializeField] private LocalizationAsset _localization;
        [FoldoutGroup("UI")] [SerializeField] private OverlayAsset _overlay;
        [FoldoutGroup("UI")] [SerializeField] private UiStateMachineAsset _uiStateMachine;
        [FoldoutGroup("UI")] [SerializeField] private EventSystemFactory _eventSystem;

        public override IGlobalServiceFactory[] GetFactories()
        {
            return new IGlobalServiceFactory[]
            {
                _applicationProxy,
                _cameraUtils,
                _currentCamera,
                _currentSceneHandler,
                _globalCamera,
                _inputView,
                _logger,
                _resourcesCleaner,
                _scenesFlow,
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
            };
        }

        public override IGlobalServiceAsyncFactory[] GetAsyncFactories()
        {
            return new IGlobalServiceAsyncFactory[]
            {
                _loadingScreen,
                _overlay,
                _publisherSdk,
            };
        }
    }
}