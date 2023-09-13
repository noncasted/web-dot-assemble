using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Result
{
    public class EmptySceneLoadResult : SceneLoadResult
    {
        public EmptySceneLoadResult(Scene scene) : base(scene)
        {
        }
        
        public EmptySceneLoadResult(SceneInstance scene) : base(scene)
        {
        }
    }
}