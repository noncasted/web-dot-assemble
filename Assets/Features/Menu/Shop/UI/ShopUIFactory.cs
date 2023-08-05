using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Shop.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Shop.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShopRoutes.ControllerName,
        menuName = ShopRoutes.ControllerPath)]
    public class ShopUIFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<ShopController>()
                .As<IShopController>();
        }
    }
}