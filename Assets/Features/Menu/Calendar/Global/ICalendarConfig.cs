using System.Collections.Generic;

namespace Menu.Calendar.Global
{
    public interface ICalendarConfig
    {
        IReadOnlyList<ICalendarDay> Days { get; }
    }
}