using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Leaderboards.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LeaderboardsRoutes.ControllerName,
        menuName = LeaderboardsRoutes.ControllerPath)]
    public class LeaderboardsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<LeaderboardsController>()
                .As<ILeaderboardsController>();
        }
    }
}