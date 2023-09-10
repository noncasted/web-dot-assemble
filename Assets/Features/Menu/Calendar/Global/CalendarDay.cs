using Global.Publisher.Abstract.Purchases;
using Menu.Calendar.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Calendar.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CalendarRoutes.DayName,
        menuName = CalendarRoutes.DayPath)]
    public class CalendarDay : ScriptableObject, ICalendarDay
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _day;
        [SerializeField] private ProductLink _product;
        [SerializeField] private bool _isPassed;

        public Sprite Icon => _icon;
        public int Day => _day;
        public IProductLink Reward => _product;
        public bool IsPassed => _isPassed;
        
        public void SetAsPassed()
        {
            _isPassed = true;
        }
    }
}