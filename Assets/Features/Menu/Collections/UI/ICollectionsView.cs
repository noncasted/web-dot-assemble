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

        void Construct(IReadOnlyList<AvatarHandle> avatars);
        void Open();
        void Disable();
    }
}