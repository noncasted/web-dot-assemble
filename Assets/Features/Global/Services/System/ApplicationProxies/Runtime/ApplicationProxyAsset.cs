using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.System.ApplicationProxies.Common;
using Global.Services.System.ApplicationProxies.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.ApplicationProxies.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.ServiceName,
        menuName = ApplicationProxyRoutes.ServicePath)]
    public class ApplicationProxyAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ApplicationProxyLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<ApplicationProxyLogger>()
                .WithParameter(_logSettings);

            builder.Register<ApplicationProxy>()
                .As<IApplicationFlow>();
        }
    }
}