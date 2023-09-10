using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Calendar.Global;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Calendar.UI
{
    [DisallowMultipleComponent]
    public class CalendarView : MonoBehaviour, ICalendarView
    {
        [SerializeField] [Min(0f)] private float _showDelay = 0.05f;

        [SerializeField] private CalendarEntryView[] _all;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        public async UniTask Show(IReadOnlyList<ICalendarDay> days, CancellationToken cancellation)
        {
            var showTasks = new UniTask[_all.Length];
            
            for (var i = 0; i < _all.Length; i++)
            {
                showTasks[i] = _all[i].Show(days[i], cancellation);
                await UniTask.Delay(_showDelay, cancellation);
            }
            
            await UniTask.WhenAll(showTasks);
        }

        public void HideInstant()
        {
            foreach (var view in _all)
                view.HideInstant();
        }
    }
}