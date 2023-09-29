using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
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
    public class AchievementsUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<AchievementsController>()
                .As<IAchievementsController>()
                .AsTab<AchievementsController>(_tabDefinition)
                .AsCallbackListener();
        }
    }
}