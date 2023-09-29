using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using GamePlay.Common.Paths;
using GamePlay.Level.Dots.Factory;
using GamePlay.Level.Scene.Runtime;
using GamePlay.Level.Services.AssembleCheck.Setup;
using GamePlay.Level.Services.DotMovers.Runtime;
using GamePlay.Level.Services.FieldFlow.Runtime;
using GamePlay.Level.Services.Score.Runtime;
using GamePlay.Loop.Runtime;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.VfxPools.Runtime;
using GamePlay.UI.Runtime;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class LevelConfig : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("Level")] [SerializeField]
        private DotFactoryServiceFactory _dotFactory;
        [FoldoutGroup("Level")] [SerializeField]
        private FieldFlowFactory _fieldFlow;
        [FoldoutGroup("Level")] [SerializeField]
        private BaseLevelSceneFactory _levelScene;
        [FoldoutGroup("Level")] [SerializeField]
        private DotMoverFactory _dotMover;
        [FoldoutGroup("Level")] [SerializeField]
        private AssembleCheckSetup _assembleCheck;
        [FoldoutGroup("Level")] [SerializeField]
        private ScoreFactory _score;
        
        [FoldoutGroup("UI")] [SerializeField]
        private LevelUiFactory _ui;
        
        [FoldoutGroup("System")] [SerializeField]
        private LevelLoopFactory _levelLoop;
        [FoldoutGroup("System")] [SerializeField]
        private VfxPoolFactory _vfxPool;

        [FoldoutGroup("Level")] [SerializeField]
        private LevelCameraFactory _levelCamera;

        [SerializeField] private LevelScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();
        public IReadOnlyList<ICallbacksFactory> Callbacks => GetCallbacks();
        
        protected IServiceFactory[] GetFactories()
        {
            var services = new IServiceFactory[]
            {
                _levelCamera,
                _levelLoop,
                _dotFactory,
                _fieldFlow,
                _dotMover,
                _assembleCheck,
                _score,
                _vfxPool,
                _levelScene,
                _ui
            };

            return services;
        }
        
        private ICallbacksFactory[] GetCallbacks()
        {
            return new ICallbacksFactory[]
            {
                new DefaultCallbacksFactory()
            };
        }
    }
}