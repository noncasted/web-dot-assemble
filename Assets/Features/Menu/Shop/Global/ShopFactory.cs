using Common.Architecture.DiContainer.Abstract;
using Global.Publisher.Abstract.Purchases;
using Global.Setup.Service;
using Menu.Shop.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Shop.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShopRoutes.ServiceName,
        menuName = ShopRoutes.ServicePath)]
    public class ShopFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private ShopProductsRegistry _productsRegistry;
        [SerializeField] private ShopConfig _config;
        
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<Shop>()
                .WithParameter<IShopConfig>(_config)
                .WithParameter(_productsRegistry)
                .As<IShop>();
        }
    }
}