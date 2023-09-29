using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
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
    public class ShopUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ShopController>()
                .As<IShopController>()
                .AsTab<ShopController>(_tabDefinition);
        }
    }
}