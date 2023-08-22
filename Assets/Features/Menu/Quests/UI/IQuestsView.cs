using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Quests.UI
{
    public interface IQuestsView
    {
        ITabNavigation Navigation { get; }

        RectTransform Transform { get; }
    }
}