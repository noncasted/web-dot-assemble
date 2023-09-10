using Global.Publisher.Abstract.Purchases;
using UnityEngine;

namespace Menu.Calendar.Global
{
    public interface ICalendarDay
    {
        Sprite Icon { get; }
        int Day { get; }
        IProductLink Reward { get; }
        bool IsPassed { get; }

        void SetAsPassed();
    }
}