using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
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
    public class CollectionsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<CollectionsController>()
                .As<ICollectionsController>()
                .AsTab<CollectionsController>(_tabDefinition);
        }
    }
}