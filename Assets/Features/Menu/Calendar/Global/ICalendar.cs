using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Menu.Calendar.Global
{
    public interface ICalendar
    {
        UniTask<IReadOnlyList<ICalendarDay>> GetCalendar();
    }
}