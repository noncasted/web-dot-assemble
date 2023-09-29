using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Menu.Main.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MainRoutes.ControllerName,
        menuName = MainRoutes.ControllerPath)]
    public class MainUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        
        public void Create(IServiceCollection builder, ILocalUtils utils)
        {
            builder.Register<MainController>()
                .As<IMainController>()
                .AsTab<MainController>(_tabDefinition);
        }
    }
}