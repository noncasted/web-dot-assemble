using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Leaderboards.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LeaderboardsRoutes.ServiceName,
        menuName = LeaderboardsRoutes.ServicePath)]
    public class LeaderboardsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private LeaderboardsConfig _config;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Leaderboards>()
                .WithParameter<ILeaderboardsConfig>(_config)
                .As<ILeaderboards>();
        }
    }
}