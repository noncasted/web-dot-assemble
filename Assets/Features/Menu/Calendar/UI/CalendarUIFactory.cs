using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Calendar.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Calendar.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CalendarRoutes.ControllerName,
        menuName = CalendarRoutes.ControllerPath)]
    public class CalendarUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<CalendarController>()
                .As<ICalendarController>()
                .AsTab<CalendarController>(_tabDefinition);
        }
    }
}