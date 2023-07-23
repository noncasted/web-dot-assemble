using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Architecture.Local.ComposedSceneConfig
{
    public class LocalServiceTransformer
    {
        public LocalServiceTransformer(Scene scene)
        {
            _scene = scene;
        }

        private readonly Scene _scene;

        public void AddService(GameObject service)
        {
            SceneManager.MoveGameObjectToScene(service, _scene);
        }
    }
}