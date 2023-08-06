using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
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
        public void Create(
            IDependencyRegister builder, 
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<MenuStateMachine>()
                .As<IMenuStateMachine>();

            builder.Register<TabsRegistry>()
                .As<ITabsRegistry>();
        }
    }
}