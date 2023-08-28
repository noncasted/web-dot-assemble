using Common.Architecture.DiContainer.Abstract;
using Global.LevelConfiguration.Common;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.LevelConfiguration.Runtime
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