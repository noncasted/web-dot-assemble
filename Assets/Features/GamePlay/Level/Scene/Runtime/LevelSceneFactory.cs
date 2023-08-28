using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Level.Scene.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Level.Scene.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelSceneRoutes.ServiceName,
        menuName = LevelSceneRoutes.ServicePath)]
    public class LevelSceneFactory : BaseLevelSceneFactory
    {
        [SerializeField] [Indent] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            IEventLoopsRegistry callbacks)
        {
            var data = new TypedSceneLoadData<SceneBootstrapper>(_scene);
            var result = await sceneLoader.Load(data);

            SceneManager.SetActiveScene(result.Scene);

            var bootstrapper = result.Searched;

            bootstrapper.Build(builder, callbacks);
        }
    }
}