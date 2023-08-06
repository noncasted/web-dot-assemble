using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Leaderboards.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LeaderboardsRoutes.ControllerName,
        menuName = LeaderboardsRoutes.ControllerPath)]
    public class LeaderboardsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;

        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<LeaderboardsController>()
                .As<ILeaderboardsController>()
                .AsTab<LeaderboardsController>(_tabDefinition);
        }
    }
}