using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Quests.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Quests.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = QuestsRoutes.ControllerName,
        menuName = QuestsRoutes.ControllerPath)]
    public class QuestsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;

        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<QuestsController>()
                .As<IQuestsController>()
                .AsTab<QuestsController>(_tabDefinition);
        }
    }
}