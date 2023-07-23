using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.System.ResourcesCleaners.Common;
using Global.Services.System.ResourcesCleaners.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.ResourcesCleaners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ResourcesCleanerRouter.ServiceName,
        menuName = ResourcesCleanerRouter.ServicePath)]
    public class ResourcesCleanerAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ResourcesCleanerLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<ResourcesCleanerLogger>().WithParameter(_logSettings);

            builder.Register<ResourcesCleaner>()
                .As<IResourcesCleaner>();
        }
    }
}