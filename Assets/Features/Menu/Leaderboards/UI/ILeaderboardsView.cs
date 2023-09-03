using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Leaderboards;
using Menu.Common.Navigation;
using Menu.Leaderboards.Global;
using UnityEngine;

namespace Menu.Leaderboards.UI
{
    public interface ILeaderboardsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
        ILeaderboardButtonsView Buttons { get; }

        UniTask Show(IReadOnlyList<LeaderboardUser> users, LeaderboardTableEntryData data,  CancellationToken cancellation);
        UniTask Hide(CancellationToken cancellation);
        void HideInstant();
    }
}