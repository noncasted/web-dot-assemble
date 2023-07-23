using Cysharp.Threading.Tasks;
using Global.Services.Scenes.ScenesFlow.Handling.Result;
using VContainer.Unity;

namespace Global.Services.Scenes.ScenesFlow.Runtime.Abstract
{
    public interface ISceneLoadHandler
    {
        UniTask<SceneLoadResult[]> Load(ISceneLoader loadHandler, LifetimeScope parent);
        void Start();
    }
}