using Common.Architecture.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.Options.Runtime;
using Global.Scenes.CurrentSceneHandlers.Runtime;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Setup.Scope;
using Global.UI.LoadingScreens.Runtime;
using Menu.Config.Runtime;

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
            IOptions options,
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
            _options = options;
        }

        private readonly ICurrentCamera _currentCamera;
        private readonly IOptions _options;
        private readonly ICurrentSceneHandler _currentSceneHandler;
        private readonly IGlobalCamera _globalCamera;

        private readonly ISceneLoader _loader;
        private readonly ILoadingScreen _loadingScreen;
        
        private readonly GlobalScope _scope;

        private readonly LevelConfig _level;
        private readonly MenuConfig _menu;

        public void OnBootstrapped()
        {
        }

        public void Start()
        {
            LoadScene(_menu).Forget();
        }

        private async UniTaskVoid LoadScene(ComposedSceneAsset asset)
        {
            _globalCamera.Enable();
            _currentCamera.SetCamera(_globalCamera.Camera);

            _loadingScreen.Show();

            var unload = _currentSceneHandler.Unload();
            var result = await asset.Load(_scope, _loader, _options);

            await unload;
            await _currentSceneHandler.FinalizeUnloading();

            _currentSceneHandler.OnLoaded(result);
            _globalCamera.Disable();
            _loadingScreen.Hide();

            result.OnLoaded();
        }
    }
}