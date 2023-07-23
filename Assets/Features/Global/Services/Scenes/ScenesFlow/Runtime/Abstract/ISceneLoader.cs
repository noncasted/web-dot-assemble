using Cysharp.Threading.Tasks;
using Global.Services.Scenes.ScenesFlow.Handling.Data;
using Global.Services.Scenes.ScenesFlow.Handling.Result;

namespace Global.Services.Scenes.ScenesFlow.Runtime.Abstract
{
    public interface ISceneLoader
    {
        UniTask<T> Load<T>(SceneLoadData<T> scene) where T : SceneLoadResult;
    }
}