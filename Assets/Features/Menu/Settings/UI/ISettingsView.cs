using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Settings.UI
{
    public interface ISettingsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
    }
}