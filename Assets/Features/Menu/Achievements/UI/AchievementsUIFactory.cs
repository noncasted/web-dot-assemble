using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Menu.Achievements.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Achievements.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AchievementsRoutes.ControllerName,
        menuName = AchievementsRoutes.ControllerPath)]
    public class AchievementsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public void Create(IServiceCollection builder, ILocalUtils utils)
        {
            builder.Register<AchievementsController>()
                .As<IAchievementsController>()
                .AsTab<AchievementsController>(_tabDefinition)
                .AsCallbackListener();
        }
    }
}