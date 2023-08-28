using System;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Settings.UI
{
    public interface ISettingsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
        
        float MusicValue { get; }
        float SoundValue { get; }

        event Action LanguageClicked;
        event Action SocialClicked;
    }
}