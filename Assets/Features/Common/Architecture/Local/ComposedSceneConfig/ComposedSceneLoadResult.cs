using System.Collections.Generic;
using Common.Architecture.Local.Services.Abstract.Callbacks;
using Global.Services.Scenes.ScenesFlow.Handling.Result;
using VContainer.Unity;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class ComposedSceneLoadResult
    {
        public ComposedSceneLoadResult(
            IReadOnlyList<SceneLoadResult> scenes,
            IReadOnlyList<ILocalDisableListener> disableListeners,
            IReadOnlyList<ILocalLoadListener> loadListeners,
            LifetimeScope scope)
        {
            Scenes = scenes;
            _disableListeners = disableListeners;
            _loadListeners = loadListeners;
            Scope = scope;
        }
        
        public ComposedSceneLoadResult(
            IReadOnlyList<SceneLoadResult> scenes,
            ComposedSceneLoadResult copy)
        {
            Scenes = scenes;
            _disableListeners = copy._disableListeners;
            _loadListeners = copy._loadListeners;
            Scope = copy.Scope;
        }

        private readonly IReadOnlyList<ILocalDisableListener> _disableListeners;
        private readonly IReadOnlyList<ILocalLoadListener> _loadListeners;

        public readonly IReadOnlyList<SceneLoadResult> Scenes;
        public LifetimeScope Scope { get; }

        public void OnLoaded()
        {
            foreach (var listener in _loadListeners)
                listener.OnLoaded();
        }

        public void OnUnload()
        {
            Scope.Dispose();

            foreach (var switchCallback in _disableListeners)
                switchCallback?.OnDisabled();
        }
    }
}