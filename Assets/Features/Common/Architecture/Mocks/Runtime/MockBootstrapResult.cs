using System.Collections.Generic;
using Common.Architecture.Local.ComposedSceneConfig;
using Cysharp.Threading.Tasks;
using Global.System.LoadedHandler.Runtime;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Native;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Common.Architecture.Mocks.Runtime
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

        public async UniTask RegisterLoadedScene(ComposedSceneLoadResult loadResult)
        {
            var scenes = new List<ISceneLoadResult>(loadResult.Scenes);
            scenes.Add(new NativeSceneLoadResult(SceneManager.GetActiveScene()));

            var newResult = new ComposedSceneLoadResult(scenes, loadResult);
            
            var sceneHandler = Resolver.Resolve<ILoadedScenesHandler>();
            sceneHandler.OnLoaded(newResult);

            await loadResult.OnLoaded();
        }
    }
}