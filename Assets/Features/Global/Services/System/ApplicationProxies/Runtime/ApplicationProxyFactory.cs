using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.ApplicationProxies.Common;
using Global.System.ApplicationProxies.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.ServiceName,
        menuName = ApplicationProxyRoutes.ServicePath)]
    public class ApplicationProxyFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ApplicationProxyLogSettings _logSettings;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<ApplicationProxyLogger>()
                .WithParameter(_logSettings);

            builder.Register<ApplicationProxy>()
                .As<IScreen>()
                .As<IApplicationFlow>();
        }
    }
}