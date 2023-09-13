using Global.Scenes.ScenesFlow.Handling.Result;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Data
{
    public class EmptySceneLoadData : SceneLoadData<EmptySceneLoadResult>
    {
        public EmptySceneLoadData(ISceneAsset asset) : base(asset)
        {
        }

        public override EmptySceneLoadResult CreateLoadResult(Scene scene)
        {
            return new EmptySceneLoadResult(scene);
        }

        public override EmptySceneLoadResult CreateLoadResult(SceneInstance sceneInstance)
        {
            return new EmptySceneLoadResult(sceneInstance);
        }
    }
}