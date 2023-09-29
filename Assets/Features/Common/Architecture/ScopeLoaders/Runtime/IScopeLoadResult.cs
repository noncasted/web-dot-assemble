using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Internal.Services.Scenes.Abstract;

namespace Common.Architecture.ScopeLoaders.Runtime
{
    public interface IScopeLoadResult
    {
        IReadOnlyDictionary<CallbackStage, ICallbacksHandler> Callbacks { get; }
        IReadOnlyList<ISceneLoadResult> Scenes { get; }
    }
}