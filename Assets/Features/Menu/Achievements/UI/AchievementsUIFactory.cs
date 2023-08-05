using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Achievements.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Achievements.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AchievementsRoutes.ControllerName,
        menuName = AchievementsRoutes.ControllerPath)]
    public class AchievementsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<AchievementsController>()
                .As<IAchievementsController>();
        }
    }
}