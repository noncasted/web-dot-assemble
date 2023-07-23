using Common.Architecture.DiContainer.Abstract;
using Global.Services.Scenes.CurrentSceneHandlers.Common;
using Global.Services.Scenes.CurrentSceneHandlers.Logs;
using Global.Services.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Scenes.CurrentSceneHandlers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentSceneHandlerRoutes.ServiceName,
        menuName = CurrentSceneHandlerRoutes.ServicePath)]
    public class CurrentSceneHandlerAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private CurrentSceneHandlerLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<CurrentSceneHandlerLogger>()
                .WithParameter(_logSettings);

            builder.Register<CurrentSceneHandler>()
                .As<ICurrentSceneHandler>();
        }
    }
}