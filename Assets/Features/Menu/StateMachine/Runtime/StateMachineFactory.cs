using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Menu.StateMachine.Common;
using Menu.StateMachine.Registry;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.StateMachine.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = StateMachineRoutes.ServiceName,
        menuName = StateMachineRoutes.ServicePath)]
    public class StateMachineFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabsTabTransitionConfig _config;
        
        public void Create(IServiceCollection builder, ILocalUtils utils)
        {
            builder.Register<StateMachine>()
                .As<IStateMachine>()
                .AsCallbackListener();

            builder.Register<TabsRegistry>()
                .As<ITabsRegistry>();

            builder.Register<TabTransitionHandler>()
                .WithParameter<ITabTransitionsConfig>(_config)
                .As<ITabTransitionHandler>();
        }
    }
}