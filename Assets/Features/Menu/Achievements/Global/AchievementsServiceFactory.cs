using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Menu.Achievements.Common;
using Menu.Achievements.Definitions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Achievements.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AchievementsRoutes.ServiceName,
        menuName = AchievementsRoutes.ServicePath)]
    public class AchievementsServiceFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private AchievementsDebug _debug;
        [SerializeField] private AchievementsRegistry _registry;
        
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            var factory = new AchievementFactory();
            
            builder.Inject(_debug);
            
            builder.Register<Achievements>()
                .WithParameter<IAchievementsConfigsRegistry>(_registry)
                .WithParameter<IAchievementFactory>(factory)
                .As<IAchievements>()
                .AsCallbackListener();
        }
    }
}