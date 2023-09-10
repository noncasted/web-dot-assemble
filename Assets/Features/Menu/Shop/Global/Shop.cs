using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Purchases;
using Global.Setup.Service.Callbacks;

namespace Menu.Shop.Global
{
    public class Shop : IShop, IGlobalAsyncAwakeListener
    {
        public Shop(IPayments payments, IDataStorage storage, IShopConfig config, ShopProductsRegistry productsRegistry)
        {
            _payments = payments;
            _storage = storage;
            _config = config;
            _productsRegistry = productsRegistry;
        }

        private readonly IPayments _payments;
        private readonly IDataStorage _storage;
        private readonly IShopConfig _config;
        private readonly ShopProductsRegistry _productsRegistry;

        public async UniTask OnAwakeAsync()
        {
            await _payments.ValidateProducts();
        }

        public async UniTask<PurchaseResult> TryPurchase(IProductLink link)
        {
            var result = await _payments.TryPurchase(link);

            switch (result)
            {
                case PurchaseResult.Success:
                    var purchasesSave = await _storage.GetEntry<PurchasesSave>(PurchasesSave.Key);
                    purchasesSave.OnPurchase(link.Id);
                    return PurchaseResult.Success;
                case PurchaseResult.Fail:
                    return PurchaseResult.Fail;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public async UniTask<IReadOnlyList<IProductLink>> GetCurrentProducts()
        {
            var purchasesSave = await _storage.GetEntry<PurchasesSave>(PurchasesSave.Key);
            var day = DateTime.UtcNow.Day;
            var count = _productsRegistry.Objects.Count;
            var products = new List<IProductLink>();

            if (purchasesSave.Purchases.Contains(_config.DisableAds.Id) == false)
                products.Add(_config.DisableAds);
            
            for (var i = 0; i < count; i++)
            {
                var index = (day + i) % count;

                products.Add(_productsRegistry.Objects[index]);
            }

            return products;
        }
    }
}