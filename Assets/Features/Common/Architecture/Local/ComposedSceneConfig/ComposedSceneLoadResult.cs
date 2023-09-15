using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Scenes.ScenesFlow.Handling.Result;
using VContainer.Unity;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class ComposedSceneLoadResult
    {
        public ComposedSceneLoadResult(
            IReadOnlyList<SceneLoadResult> scenes,
            CallbacksHandler disableCallbacks,
            CallbacksHandler loadCallbacks,
            LifetimeScope scope)
        {
            Scenes = scenes;
            _disableCallbacks = disableCallbacks;
            _loadCallbacks = loadCallbacks;
            _scope = scope;
        }
        
        public ComposedSceneLoadResult(
            IReadOnlyList<SceneLoadResult> scenes,
            ComposedSceneLoadResult copy)
        {
            Scenes = scenes;
            _disableCallbacks = copy._disableCallbacks;
            _loadCallbacks = copy._loadCallbacks;
            _scope = copy._scope;
        }

        private readonly CallbacksHandler _disableCallbacks;
        private readonly CallbacksHandler _loadCallbacks;
        private readonly LifetimeScope _scope;

        public readonly IReadOnlyList<SceneLoadResult> Scenes;

        public async UniTask OnLoaded()
        {
            await _loadCallbacks.Run();
        }

        public async UniTask OnUnload()
        {
            _scope.Dispose();

            await _disableCallbacks.Run();
        }
    }
}