using System.Collections.Generic;
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

        void Enable();
        void Disable();

        void Construct(IReadOnlyList<IAchievement> achievement);
        UniTask Open();
    }
}