using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Services.Scenes.ScenesFlow.Handling.Result;

namespace Global.Services.Scenes.ScenesFlow.Runtime.Abstract
{
    public interface ISceneUnloader
    {
        UniTask Unload(SceneLoadResult result);

        UniTask Unload(IReadOnlyList<SceneLoadResult> scenes);
    }
}