using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Menu.Leaderboards.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Leaderboards.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LeaderboardsRoutes.ServiceName,
        menuName = LeaderboardsRoutes.ServicePath)]
    public class LeaderboardsFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private LeaderboardsConfig _config;
        
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<Leaderboards>()
                .WithParameter<ILeaderboardsConfig>(_config)
                .As<ILeaderboards>();
        }
    }
}