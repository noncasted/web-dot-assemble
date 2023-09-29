using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Common;
using Menu.Achievements.Definitions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Achievements.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AchievementsRoutes.ServiceName,
        menuName = AchievementsRoutes.ServicePath)]
    public class AchievementsServiceFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private AchievementsDebug _debug;
        [SerializeField] private AchievementsRegistry _registry;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var factory = new AchievementFactory();
            
            services.Inject(_debug);
            
            services.Register<Achievements>()
                .WithParameter<IAchievementsConfigsRegistry>(_registry)
                .WithParameter<IAchievementFactory>(factory)
                .As<IAchievements>()
                .AsCallbackListener();
        }
    }
}