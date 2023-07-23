using Common.Architecture.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.Services.Cameras.CurrentCameras.Runtime;
using Global.Services.Cameras.GlobalCameras.Runtime;
using Global.Services.Scenes.CurrentSceneHandlers.Runtime;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Services.Setup.Scope;
using Global.Services.System.MessageBrokers.Runtime;
using Global.Services.UI.LoadingScreens.Runtime;
using Menu.Config.Runtime;
using Menu.Loop.Runtime;

namespace Global.GameLoops.Runtime
{
    public class GameLoop : IGameLoop
    {
        public GameLoop(
            GlobalScope scope,
            ISceneLoader loader,
            ILoadingScreen loadingScreen,
            IGlobalCamera globalCamera,
            ICurrentSceneHandler currentSceneHandler,
            ICurrentCamera currentCamera,
            LevelConfig level,
            MenuConfig menu)
        {
            _level = level;
            _menu = menu;
            _scope = scope;
            _loader = loader;
            _loadingScreen = loadingScreen;
            _globalCamera = globalCamera;
            _currentSceneHandler = currentSceneHandler;
            _currentCamera = currentCamera;
        }

        private readonly ICurrentCamera _currentCamera;
        private readonly ICurrentSceneHandler _currentSceneHandler;
        private readonly IGlobalCamera _globalCamera;

        private readonly ISceneLoader _loader;
        private readonly ILoadingScreen _loadingScreen;
        
        private readonly GlobalScope _scope;

        private readonly LevelConfig _level;
        private readonly MenuConfig _menu;

        public void OnBootstrapped()
        {
            Msg.Listen<LevelTransitionRequestEvent>(OnLevelTransitionRequested);
        }

        public void Start()
        {
            LoadScene(_menu).Forget();
        }

        private void OnLevelTransitionRequested(LevelTransitionRequestEvent request)
        {
            LoadScene(_level).Forget();
        }

        private async UniTaskVoid LoadScene(ComposedSceneAsset asset)
        {
            _globalCamera.Enable();
            _currentCamera.SetCamera(_globalCamera.Camera);

            _loadingScreen.Show();

            var unload = _currentSceneHandler.Unload();
            var result = await asset.Load(_scope, _loader);

            await unload;
            await _currentSceneHandler.FinalizeUnloading();

            _currentSceneHandler.OnLoaded(result);
            _globalCamera.Disable();
            _loadingScreen.Hide();

            result.OnLoaded();
        }
    }
}