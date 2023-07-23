using Common.Architecture.Local.ComposedSceneConfig;
using Common.Architecture.Local.Services.Abstract;
using GamePlay.Common.Paths;
using GamePlay.Loop.Runtime;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.VfxPools.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class LevelConfig : ComposedSceneAsset
    {
        [FoldoutGroup("System")] [SerializeField]
        private LevelLoopAsset _levelLoop;
        [FoldoutGroup("System")] [SerializeField]
        private VfxPoolAsset _vfxPool;

        [FoldoutGroup("Level")] [SerializeField]
        private LevelCameraAsset _levelCamera;

        [SerializeField] private LevelScope _scopePrefab;

        protected override ILocalServiceFactory[] GetFactories()
        {
            var services = new ILocalServiceFactory[]
            {
                _levelCamera,
                _levelLoop,
            };

            return services;
        }

        protected override ILocalServiceAsyncFactory[] GetAsyncFactories()
        {
            var services = new ILocalServiceAsyncFactory[]
            {
                _vfxPool,
            };

            return services;
        }

        protected override LifetimeScope AssignScope()
        {
            return _scopePrefab;
        }
    }
}