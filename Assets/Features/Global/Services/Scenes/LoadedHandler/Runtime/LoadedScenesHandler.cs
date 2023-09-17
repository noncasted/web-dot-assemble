using Common.Architecture.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;
using Global.Scenes.LoadedHandler.Logs;
using Global.Scenes.Operations.Abstract;
using Global.System.ResourcesCleaners.Runtime;

namespace Global.Scenes.LoadedHandler.Runtime
{
    public class LoadedScenesHandler : ILoadedScenesHandler
    {
        public LoadedScenesHandler(
            ISceneUnloader sceneUnload,
            IResourcesCleaner resourcesCleaner,
            LoadedScenesHandlerLogger logger)
        {
            _logger = logger;
            _sceneUnload = sceneUnload;
            _resourcesCleaner = resourcesCleaner;
        }

        private readonly LoadedScenesHandlerLogger _logger;

        private readonly IResourcesCleaner _resourcesCleaner;
        private readonly ISceneUnloader _sceneUnload;

        private ComposedSceneLoadResult _current;

        public void OnLoaded(ComposedSceneLoadResult loaded)
        {
            _current = loaded;

            _logger.OnLoaded(_current.Scenes.Count);
        }

        public async UniTask Unload()
        {
            if (_current == null)
            {
                _logger.OnNoCurrentSceneError();
                return;
            }

            _logger.OnUnload(_current.Scenes.Count);

            await _current.OnUnload();

            await _sceneUnload.Unload(_current.Scenes);
        }

        public async UniTask FinalizeUnloading()
        {
            await _resourcesCleaner.CleanUp();

            _logger.OnUnloadingFinalized();
        }
    }
}