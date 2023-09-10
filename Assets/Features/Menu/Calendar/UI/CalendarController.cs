using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Calendar.Global;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Calendar.UI
{
    public class CalendarController : ICalendarController, ITab
    {
        public CalendarController(
            ICalendarView view,
            ICalendar calendar)
        {
            _view = view;
            _calendar = calendar;
        }

        private readonly ICalendarView _view;
        private readonly ICalendar _calendar;

        private CancellationTokenSource _cancellation;

        public RectTransform Transform => _view.Transform;

        public void Activate()
        {
            _view.Navigation.Enable();

            Cancel();
            _cancellation = new CancellationTokenSource();
            
            _view.HideInstant();
            Show().Forget();
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
            _view.HideInstant();
            Cancel();
        }

        private async UniTaskVoid Show()
        {
            var days = await _calendar.GetCalendar();
            _view.Show(days, _cancellation.Token);
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }
    }
}