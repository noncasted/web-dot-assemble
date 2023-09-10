using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Calendar.Global;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Calendar.UI
{
    public interface ICalendarView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }

        UniTask Show(IReadOnlyList<ICalendarDay> days,  CancellationToken cancellation);
        void HideInstant();
    }
}