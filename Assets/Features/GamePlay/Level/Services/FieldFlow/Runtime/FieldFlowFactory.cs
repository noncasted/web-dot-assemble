using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
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
    public class FieldFlowFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private DotDefinitionsStorage _storage;
        [SerializeField] [Min(0)] private int _dotLifeCycleAmount = 3;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var lifeFlowConfig = new DotLifeFlowConfig(_dotLifeCycleAmount);

            services.Register<FieldLifetime>()
                .As<IFieldLifetime>();

            services.Register<FieldSeeder>()
                .WithParameter<IDotDefinitionsStorage>(_storage)
                .WithParameter<IDotLifeFlowConfig>(lifeFlowConfig)
                .As<IFieldSeeder>();

            services.Register<FieldFlow>()
                .As<IFieldFlow>();
        }
    }
}