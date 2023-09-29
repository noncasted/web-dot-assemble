using Common.Architecture.DiContainer.Abstract;
using GamePlay.Common.SceneBootstrappers.Runtime;
using GamePlay.Level.Fields.Factory;
using GamePlay.Level.Services.DotMovers.Runtime;
using UnityEngine;

namespace GamePlay.Level.Scene.Runtime
{
    [DisallowMultipleComponent]
    public class LevelSceneDependenciesRegister : SceneComponentRegister
    {
        [SerializeField] private Transform _cellsRoot;
        [SerializeField] private Transform _moveRect;

        public override void Register(IServiceCollection builder)
        {
            var fieldFactory = new FieldFactory(_cellsRoot);
            var scanner = new FieldScanner();
            var validator = new FieldValidator();
            var field = fieldFactory.Create(scanner, validator);

            builder.RegisterInstance(field);

            builder.Register<MoveRectProvider>()
                .WithParameter(_moveRect)
                .As<IMoveRectProvider>();
        }
    }
}