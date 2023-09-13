using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.ResourcesCleaners.Common;
using Global.System.ResourcesCleaners.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ResourcesCleaners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ResourcesCleanerRouter.ServiceName,
        menuName = ResourcesCleanerRouter.ServicePath)]
    public class ResourcesCleanerFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private ResourcesCleanerLogSettings _logSettings;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<ResourcesCleanerLogger>().WithParameter(_logSettings);

            builder.Register<ResourcesCleaner>()
                .As<IResourcesCleaner>();
        }
    }
}