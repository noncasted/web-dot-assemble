using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Menu.Achievements.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Achievements.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AchievementsRoutes.ServiceName,
        menuName = AchievementsRoutes.ServicePath)]
    public class AchievementsServiceFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Achievements>()
                .As<IAchievements>()
                .AsCallbackListener();
        }
    }
}