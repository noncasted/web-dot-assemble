using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Global.Scenes.Operations.Abstract
{
    public interface ISceneUnloader
    {
        UniTask Unload(ISceneLoadResult result);

        UniTask Unload(IReadOnlyList<ISceneLoadResult> results);
    }
}