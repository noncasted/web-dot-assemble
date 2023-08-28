using System.Collections.Generic;
using Common.Architecture.Local.ComposedSceneConfig;
using Global.Scenes.CurrentSceneHandlers.Runtime;
using Global.Scenes.ScenesFlow.Handling.Result;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Common.Architecture.Mocks
{
    public class MockBootstrapResult
    {
        public MockBootstrapResult(LifetimeScope parent)
        {
            Parent = parent;
            Resolver = parent.Container;
        }
        
        public readonly IObjectResolver Resolver;
        public readonly LifetimeScope Parent;

        public void RegisterLoadedScene(ComposedSceneLoadResult loadResult)
        {
            var scenes = new List<SceneLoadResult>(loadResult.Scenes);
            scenes.Add(new EmptySceneLoadResult(SceneManager.GetActiveScene()));

            var newResult = new ComposedSceneLoadResult(scenes, loadResult);
            
            var sceneHandler = Resolver.Resolve<ICurrentSceneHandler>();
            sceneHandler.OnLoaded(newResult);

            loadResult.OnLoaded();
        }
    }
}