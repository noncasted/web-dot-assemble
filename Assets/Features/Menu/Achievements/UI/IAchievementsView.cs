using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Achievements.UI
{
    public interface IAchievementsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
    }
}