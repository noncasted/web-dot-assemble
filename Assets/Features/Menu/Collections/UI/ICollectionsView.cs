using System;
using System.Collections.Generic;
using Menu.Collections.Global;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Collections.UI
{
    public interface ICollectionsView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }

        void Enable();
        void Disable();
        void Construct(IReadOnlyList<AvatarHandle> achievement);
        void Open();
    }
}