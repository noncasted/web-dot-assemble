using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Purchases;

namespace Menu.Shop.UI
{
    public interface IShopEntry
    {
        IReadOnlyList<IProductLink> PrimaryProducts { get; }
        
        event Action<IProductLink> BuyRequested;
        
        UniTask Show(IProductLink productLink);
    }
}