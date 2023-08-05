using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Menu.Settings.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Settings.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SettingsRoutes.ServiceName,
        menuName = SettingsRoutes.ServicePath)]
    public class SettingsFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Settings>()
                .As<ISettings>();
        }
    }
}