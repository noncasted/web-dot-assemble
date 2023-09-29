using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Level.Scene.Common;
using Internal.Services.Scenes.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Scene.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelSceneRoutes.MockName,
        menuName = LevelSceneRoutes.MockPath)]
    public class MockLevelSceneFactory : BaseLevelSceneFactory
    {
        public override async UniTask Create(IServiceCollection builder,ISceneLoader sceneLoader, ILocalUtils utils)
        {
            var bootstrapper = FindFirstObjectByType<SceneBootstrapper>();

            bootstrapper.Build(builder, utils.LoopsRegistry);
        }
    }
}