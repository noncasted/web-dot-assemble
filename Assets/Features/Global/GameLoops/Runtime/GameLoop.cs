using Common.Architecture.Local.ComposedSceneConfig;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.System.LoadedHandler.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using Menu.Config.Runtime;
using VContainer.Unity;

namespace Global.GameLoops.Runtime
{
    public class GameLoop : IScopeLoadAsyncListener
    {
        public GameLoop(
            LifetimeScope scope,
            ISceneLoader loader,
            ILoadingScreen loadingScreen,
            IGlobalCamera globalCamera,
            ILoadedScenesHandler loadedScenesHandler,
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
            _loadedScenesHandler = loadedScenesHandler;
            _currentCamera = currentCamera;
            _options = options;
        }

        private readonly ICurrentCamera _currentCamera;
        private readonly IOptions _options;
        private readonly ILoadedScenesHandler _loadedScenesHandler;
        private readonly IGlobalCamera _globalCamera;

        private readonly ISceneLoader _loader;
        private readonly ILoadingScreen _loadingScreen;

        private readonly LifetimeScope _scope;

        private readonly LevelConfig _level;
        private readonly MenuConfig _menu;

        public async UniTask OnLoadedAsync()
        {
            LoadScene(_menu).Forget();
        }

        private async UniTaskVoid LoadScene(ComposedSceneAsset asset)
        {
            _globalCamera.Enable();
            _currentCamera.SetCamera(_globalCamera.Camera);

            _loadingScreen.Show();

            var unload = _loadedScenesHandler.Unload();
            var result = await asset.Load(_scope, _loader, _options);

            await unload;
            await _loadedScenesHandler.FinalizeUnloading();

            _loadedScenesHandler.OnLoaded(result);
            _globalCamera.Disable();
            _loadingScreen.Hide();

            await result.OnLoaded();
        }
    }
}