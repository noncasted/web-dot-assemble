using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Leaderboards.Common;
using Menu.Leaderboards.Global;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LeaderboardsRoutes.ControllerName,
        menuName = LeaderboardsRoutes.ControllerPath)]
    public class LeaderboardsUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        [SerializeField] private LeaderboardsTableEntriesConfig _entriesConfig;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<LeaderboardsController>()
                .As<ILeaderboardsController>()
                .WithParameter(_entriesConfig)
                .AsTab<LeaderboardsController>(_tabDefinition);
        }
    }
}