using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Collections.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Collections.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CollectionsRoutes.ControllerName,
        menuName = CollectionsRoutes.ControllerPath)]
    public class CollectionsUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<CollectionsController>()
                .As<ICollectionsController>()
                .AsTab<CollectionsController>(_tabDefinition)
                .AsCallbackListener();
        }
    }
}