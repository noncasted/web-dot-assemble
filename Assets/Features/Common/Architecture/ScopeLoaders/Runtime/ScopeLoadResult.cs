using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Internal.Services.Scenes.Abstract;

namespace Common.Architecture.ScopeLoaders.Runtime
{
    public class ScopeLoadResult : IScopeLoadResult
    {
        public ScopeLoadResult(IScopeCallbacks callbacks, ScopeSceneLoader sceneLoader)
        {
            _callbacks = callbacks;
            _sceneLoader = sceneLoader;
        }
        
        private readonly IScopeCallbacks _callbacks;
        private readonly ScopeSceneLoader _sceneLoader;

        public IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Callbacks => _callbacks.Handlers;
        public IReadOnlyList<ISceneLoadResult> Scenes => _sceneLoader.Results;
    }
}