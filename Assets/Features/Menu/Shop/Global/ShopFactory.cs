using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Purchases;
using Menu.Shop.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Shop.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShopRoutes.ServiceName,
        menuName = ShopRoutes.ServicePath)]
    public class ShopFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private ShopProductsRegistry _productsRegistry;
        [SerializeField] private ShopConfig _config;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Shop>()
                .WithParameter<IShopConfig>(_config)
                .WithParameter(_productsRegistry)
                .As<IShop>();
        }
    }
}