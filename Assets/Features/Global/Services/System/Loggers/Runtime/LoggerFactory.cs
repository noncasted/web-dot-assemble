using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.Loggers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Loggers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoggerRoutes.ServiceName,
        menuName = LoggerRoutes.ServicePath)]
    public class LoggerFactory : ScriptableObject, IGlobalServiceFactory
    {
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<Logger>()
                .As<ILogger>();
        }
    }
}