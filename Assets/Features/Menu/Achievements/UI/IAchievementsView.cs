using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Achievements.Definitions;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Achievements.UI
{
    public interface IAchievementsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }

        void Construct(IReadOnlyList<IAchievement> achievement);
        UniTask Open(CancellationToken cancellation);
    }
}