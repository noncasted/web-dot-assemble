using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.Shop.Global;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Shop.UI
{
    public class ShopController : IShopController, ITab
    {
        public ShopController(IShopView view, IShop shop)
        {
            _view = view;
            _shop = shop;
        }

        private readonly IShopView _view;
        private readonly IShop _shop;

        private CancellationTokenSource _cancellation;

        public RectTransform Transform => _view.Transform;
        
        public void Activate()
        {
            _cancellation = new CancellationTokenSource();
            
            Show(_cancellation.Token).Forget();
        }

        public void Deactivate()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }

        private async UniTask Show(CancellationToken cancellation)
        {
            var products = await _shop.GetCurrentProducts();
            await _view.Show(products, cancellation);
        }
    }
}