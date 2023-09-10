using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Purchases;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Shop.UI
{
    public interface IShopView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }

        UniTask Show(IReadOnlyList<IProductLink> products, CancellationToken cancellation);
    }
}