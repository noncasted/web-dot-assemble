using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using Menu.Settings.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Settings.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SettingsRoutes.ControllerName,
        menuName = SettingsRoutes.ControllerPath)]
    public class SettingsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;

        public void Create(IServiceCollection builder, ILocalUtils utils)
        {
            builder.Register<SettingsController>()
                .As<ISettingsController>()
                .AsTab<SettingsController>(_tabDefinition);
        }
    }
}