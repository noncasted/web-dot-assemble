using Common.Architecture.DiContainer.Abstract;
using Global.Services.LevelConfiguration.Common;
using Global.Services.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.LevelConfiguration.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelConfigurationRoutes.ServiceName,
        menuName = LevelConfigurationRoutes.ServicePath)]
    public class LevelConfigurationFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<LevelConfigurationProvider>()
                .As<ILevelConfigurationProvider>();
        }
    }
}