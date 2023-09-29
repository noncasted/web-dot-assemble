using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.Serialization.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using Global.LevelConfigurations.Common;
using Global.LevelConfigurations.Definition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfigurations.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.ServiceName,
        menuName = LevelConfigurationRoutes.ServicePath)]
    public class LevelConfigurationFactory : ScriptableRegistry<LevelConfiguration>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var configurations = Objects as IReadOnlyList<ILevelConfiguration>;
            services.Register<LevelConfigurationProvider>()
                .WithParameter(configurations)
                .As<ILevelConfigurationProvider>();
        }
    }
}