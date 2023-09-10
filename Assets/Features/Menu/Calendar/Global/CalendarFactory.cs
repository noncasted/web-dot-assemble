using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Menu.Calendar.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Calendar.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CalendarRoutes.ServiceName,
        menuName = CalendarRoutes.ServicePath)]
    public class CalendarFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private CalendarConfig _config;
        
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Calendar>()
                .WithParameter<ICalendarConfig>(_config)
                .As<ICalendar>();
        }
    }
}