using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Purchases;

namespace Menu.Shop.Global
{
    public interface IShop
    {
        UniTask<PurchaseResult> TryPurchase(IProductLink product);
        UniTask<IReadOnlyList<IProductLink>> GetCurrentProducts();
    }
}