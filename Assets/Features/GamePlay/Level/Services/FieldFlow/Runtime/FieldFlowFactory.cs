using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using GamePlay.Level.Dots.Definitions;
using GamePlay.Level.Dots.Runtime.LifeFlow;
using GamePlay.Level.Fields.Lifetime;
using GamePlay.Level.Services.FieldFlow.Common;
using GamePlay.Level.Services.FieldFlow.Seeder;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Services.FieldFlow.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = FieldFlowRoutes.ServiceName,
        menuName = FieldFlowRoutes.ServicePath)]
    public class FieldFlowFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private DotDefinitionsStorage _storage;
        [SerializeField] [Min(0)] private int _dotLifeCycleAmount = 3;

        public void Create(IServiceCollection builder, ILocalUtils utils)
        {
            var lifeFlowConfig = new DotLifeFlowConfig(_dotLifeCycleAmount);

            builder.Register<FieldLifetime>()
                .As<IFieldLifetime>();

            builder.Register<FieldSeeder>()
                .WithParameter<IDotDefinitionsStorage>(_storage)
                .WithParameter<IDotLifeFlowConfig>(lifeFlowConfig)
                .As<IFieldSeeder>();

            builder.Register<FieldFlow>()
                .As<IFieldFlow>();
        }
    }
}