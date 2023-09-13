using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Level.Scene.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
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

        public override async UniTask Create(IDependencyRegister builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var data = new TypedSceneLoadData<SceneBootstrapper>(_scene);
            var result = await sceneLoader.Load(data);

            SceneManager.SetActiveScene(result.Scene);

            var bootstrapper = result.Searched;

            bootstrapper.Build(builder, utils.LoopsRegistry);
        }
    }
}