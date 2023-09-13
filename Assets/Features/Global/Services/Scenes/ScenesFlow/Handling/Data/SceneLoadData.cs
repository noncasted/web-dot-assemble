using Global.Scenes.ScenesFlow.Handling.Result;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Data
{
    public abstract class SceneLoadData<T> where T : SceneLoadResult
    {
        public SceneLoadData(ISceneAsset asset)
        {
            Asset = asset;
        }

        public readonly ISceneAsset Asset;

        public abstract T CreateLoadResult(Scene scene);
        public abstract T CreateLoadResult(SceneInstance sceneInstance);
    }
}