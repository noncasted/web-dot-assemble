using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.Serialization.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Definitions;
using Global.LevelConfigurations.Avatars;
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
        [SerializeField] private DotDefinitionsStorage _dotDefinitionsStorage;
        [SerializeField] private AvatarsRegistry _avatarsRegistry;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var configurations = Objects as IReadOnlyList<ILevelConfiguration>;
            
            services.Register<LevelConfigurationProvider>()
                .WithParameter(configurations)
                .As<ILevelConfigurationProvider>()
                .AsCallbackListener();

            services.RegisterInstance(_avatarsRegistry)
                .As<IAvatarsRegistry>();

            services.RegisterInstance(_dotDefinitionsStorage)
                .As<IDotDefinitionsStorage>()
                .AsSelfResolvable();
        }
    }
}