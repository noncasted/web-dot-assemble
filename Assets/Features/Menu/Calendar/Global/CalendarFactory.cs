using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Calendar.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Calendar.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CalendarRoutes.ServiceName,
        menuName = CalendarRoutes.ServicePath)]
    public class CalendarFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private CalendarConfig _config;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Calendar>()
                .WithParameter<ICalendarConfig>(_config)
                .As<ICalendar>();
        }
    }
}