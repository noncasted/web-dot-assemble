using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Menu.Common.Navigation;
using Menu.Common.Tasks.Abstract;
using UnityEngine;

namespace Menu.Achievements.UI
{
    public interface IAchievementsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }

        void Enable();
        void Disable();

        void Construct(IReadOnlyList<IGoalTask> achievement);
        UniTask Open();
    }
}