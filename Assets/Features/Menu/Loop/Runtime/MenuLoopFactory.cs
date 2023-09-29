using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Menu.Loop.Common;
using Menu.StateMachine.Definitions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoopRoutes.ServiceName,
        menuName = LoopRoutes.ServicePath)]
    public class MenuLoopFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _mainDefinition;
        
        public void Create(IServiceCollection builder, ILocalUtils utils)
        {
            builder.Register<MenuLoop>()
                .WithParameter<ITabDefinition>(_mainDefinition)
                .AsCallbackListener();
        }
    }
}