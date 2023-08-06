using Features.Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Collections.UI
{
    public interface ICollectionsView
    {
        ITabNavigation Navigation { get; }
        
        RectTransform Transform { get; }
    }
}