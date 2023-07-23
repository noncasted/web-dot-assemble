using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.System.Loggers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.Loggers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoggerRoutes.ServiceName,
        menuName = LoggerRoutes.ServicePath)]
    public class LoggerAsset : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Logger>()
                .As<ILogger>();
        }
    }
}