using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Services.Abstract;
using Menu.Settings.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Settings.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SettingsRoutes.ControllerName,
        menuName = SettingsRoutes.ControllerPath)]
    public class SettingsUIFactory : ScriptableObject, ILocalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            IEventLoopsRegistry loopsRegistry)
        {
            builder.Register<SettingsController>()
                .As<ISettingsController>();
        }
    }
}