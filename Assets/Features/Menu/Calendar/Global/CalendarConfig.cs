using System.Collections.Generic;
using Common.Serialization.ScriptableRegistries;
using Menu.Calendar.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Calendar.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CalendarRoutes.ConfigName, 
        menuName = CalendarRoutes.ConfigPath)]
    public class CalendarConfig : ScriptableRegistry<CalendarDay>, ICalendarConfig
    {
        public IReadOnlyList<ICalendarDay> Days => Objects;
    }
}