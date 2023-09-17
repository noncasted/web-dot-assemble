using Global.Scenes.Operations.Abstract;
using UnityEngine.SceneManagement;

namespace Global.Scenes.Operations.Native
{
    public class NativeSceneLoadResult : ISceneLoadResult
    {
        public NativeSceneLoadResult(Scene scene)
        {
            _scene = scene;
        }
        
        private readonly Scene _scene;

        public Scene Scene => _scene;
    }
}