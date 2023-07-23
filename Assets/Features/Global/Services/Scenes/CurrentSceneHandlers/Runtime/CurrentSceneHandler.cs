using Common.Architecture.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;
using Global.Services.Scenes.CurrentSceneHandlers.Logs;
using Global.Services.Scenes.ScenesFlow.Runtime.Abstract;
using Global.Services.System.ResourcesCleaners.Runtime;

namespace Global.Services.Scenes.CurrentSceneHandlers.Runtime
{
    public class CurrentSceneHandler : ICurrentSceneHandler
    {
        public CurrentSceneHandler(
            ISceneUnloader unloader,
            IResourcesCleaner resourcesCleaner,
            CurrentSceneHandlerLogger logger)
        {
            _logger = logger;
            _unloader = unloader;
            _resourcesCleaner = resourcesCleaner;
        }

        private readonly CurrentSceneHandlerLogger _logger;

        private readonly IResourcesCleaner _resourcesCleaner;
        private readonly ISceneUnloader _unloader;

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

            _current.OnUnload();

            await _unloader.Unload(_current.Scenes);
        }

        public async UniTask FinalizeUnloading()
        {
            await _resourcesCleaner.CleanUp();

            _logger.OnUnloadingFinalized();
        }
    }
}