using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Result
{
    public abstract class SceneLoadResult
    {
        public SceneLoadResult(Scene scene)
        {
            Scene = scene;
        }
        
        public SceneLoadResult(SceneInstance sceneInstance)
        {
            Scene = sceneInstance.Scene;
            SceneInstance = sceneInstance;
        }

        public readonly Scene Scene;
        public readonly SceneInstance SceneInstance;
    }
}