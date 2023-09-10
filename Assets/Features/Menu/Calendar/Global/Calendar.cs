using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;

namespace Menu.Calendar.Global
{
    public class Calendar : ICalendar
    {
        public Calendar(ICalendarConfig config, IDataStorage dataStorage)
        {
            _config = config;
            _dataStorage = dataStorage;
        }

        private readonly ICalendarConfig _config;
        private readonly IDataStorage _dataStorage;

        public async UniTask<IReadOnlyList<ICalendarDay>> GetCalendar()
        {
            var save = await _dataStorage.GetEntry<CalendarSave>(CalendarSave.Key);
            var daysList = _config.Days;
            var days = daysList.ToDictionary(day => day.Day);

            foreach (var passedDay in save.PassedDays)
                days[passedDay].SetAsPassed();

            return daysList.OrderBy(day => day.Day).ToList();
        }
    }
}