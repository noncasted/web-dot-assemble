using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Shop.UI
{
    public interface IShopView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
    }
}