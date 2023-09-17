using Global.Scenes.Operations.Abstract;
using UnityEngine.SceneManagement;

namespace Global.Scenes.Operations.Native
{
    public class NativeSceneLoadTypedResult<T> : ISceneLoadTypedResult<T>
    {
        public NativeSceneLoadTypedResult(Scene scene, T searched)
        {
            _scene = scene;
            Searched = searched;
        }
        
        private readonly Scene _scene;

        public T Searched { get; }
        public Scene Scene => _scene;
    }
}