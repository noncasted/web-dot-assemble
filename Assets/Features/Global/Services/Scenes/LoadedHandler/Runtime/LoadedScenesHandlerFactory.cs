using Common.Architecture.DiContainer.Abstract;
using Global.Scenes.LoadedHandler.Common;
using Global.Scenes.LoadedHandler.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Scenes.LoadedHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoadedScenesHandlerRoutes.ServiceName,
        menuName = LoadedScenesHandlerRoutes.ServicePath)]
    public class LoadedScenesHandlerFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private LoadedScenesHandlerLogSettings _logSettings;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<LoadedScenesHandlerLogger>()
                .WithParameter(_logSettings);

            builder.Register<LoadedScenesHandler>()
                .As<ILoadedScensHandler>();
        }
    }
}