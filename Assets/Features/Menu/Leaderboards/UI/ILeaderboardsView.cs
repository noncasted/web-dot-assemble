using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    public interface ILeaderboardsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
    }
}