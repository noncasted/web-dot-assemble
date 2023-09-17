using System;

namespace Menu.Leaderboards.UI
{
    public interface ILeaderboardButtonsView
    {
        event Action NextClicked;
        event Action PreviousClicked;
    }
}