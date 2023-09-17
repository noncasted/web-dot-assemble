using Cysharp.Threading.Tasks;
using Global.Scenes.Operations.Data;

namespace Global.Scenes.Operations.Abstract
{
    public interface ISceneLoader
    {
        UniTask<ISceneLoadResult> Load(ISceneAsset sceneAsset);
        UniTask<ISceneLoadTypedResult<T>> LoadTyped<T>(ISceneAsset sceneAsset);
    }
}