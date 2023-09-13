using System;
using Global.Scenes.ScenesFlow.Handling.Result;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Global.Scenes.ScenesFlow.Handling.Data
{
    public class TypedSceneLoadData<T> : SceneLoadData<TypedSceneLoadResult<T>>
    {
        public TypedSceneLoadData(ISceneAsset asset) : base(asset)
        {
        }

        public override TypedSceneLoadResult<T> CreateLoadResult(Scene scene)
        {
            var searched = Search(scene);

            return new TypedSceneLoadResult<T>(scene, searched);
        }
        
        public override TypedSceneLoadResult<T> CreateLoadResult(SceneInstance sceneInstance)
        {
            var searched = Search(sceneInstance.Scene);

            return new TypedSceneLoadResult<T>(sceneInstance, searched);
        }

        private T Search(Scene scene)
        {
            var rootObjects = scene.GetRootGameObjects();
            foreach (var rootObject in rootObjects)
                if (rootObject.TryGetComponent(out T searched) == true)
                    return searched;

            throw new NullReferenceException($"Searched {typeof(T)} is not found");
        }
    }
}