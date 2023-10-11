using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.Serialization.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Common;
using Menu.Common.Tasks.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Achievements.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AchievementsRoutes.ServiceName,
        menuName = AchievementsRoutes.ServicePath)]
    public class AchievementsServiceFactory : ScriptableRegistry<AchievementFactory>, IServiceFactory
    {
        [SerializeField] private AchievementsDebug _debug;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Inject(_debug);
            
            services.Register<Achievements>()
                .WithParameter<IReadOnlyList<ITaskFactory>>(Objects)
                .As<IAchievements>()
                .AsCallbackListener();
        }
    }
}