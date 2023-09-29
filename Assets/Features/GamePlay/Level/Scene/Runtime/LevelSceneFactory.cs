using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Level.Scene.Common;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Data;
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
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;

        public override async UniTask Create(IServiceCollection builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var result = await sceneLoader.LoadTyped<SceneBootstrapper>(_scene);

            SceneManager.SetActiveScene(result.Scene);

            var bootstrapper = result.Searched;

            bootstrapper.Build(builder, utils.LoopsRegistry);
        }
    }
}