using System;
using System.Collections.Generic;
using System.Linq;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Abstract.Purchases;
using Global.System.MessageBrokers.Runtime;

namespace Menu.Shop.Global
{
    public class Shop : IShop, IScopeEnableAsyncListener
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

        public async UniTask OnEnabledAsync()
        {
            await _payments.ValidateProducts();
        }

        public async UniTask<PurchaseResult> TryPurchase(IProductLink product)
        {
            var result = await _payments.TryPurchase(product);

            switch (result)
            {
                case PurchaseResult.Success:
                {
                    var purchasesSave = await _storage.GetEntry<PurchasesSave>(PurchasesSave.Key);
                    purchasesSave.OnPurchase(product.Id);
                    Msg.Publish(new PurchaseEvent(product));
                    return PurchaseResult.Success;
                }
                case PurchaseResult.Fail:
                {
                    return PurchaseResult.Fail;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
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