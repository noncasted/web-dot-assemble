using Common.Architecture.DiContainer.Abstract;
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
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Shop>()
                .As<IShop>();
        }
    }
}