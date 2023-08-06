using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Shop.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Shop.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ShopRoutes.ControllerName,
        menuName = ShopRoutes.ControllerPath)]
    public class ShopUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public void Create(IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<ShopController>()
                .As<IShopController>()
                .AsTab<ShopController>(_tabDefinition);
        }
    }
}