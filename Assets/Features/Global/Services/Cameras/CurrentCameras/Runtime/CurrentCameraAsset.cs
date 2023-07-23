using Common.Architecture.DiContainer.Abstract;
using Global.Services.Cameras.CurrentCameras.Common;
using Global.Services.Cameras.CurrentCameras.Logs;
using Global.Services.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.Cameras.CurrentCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.ServiceName,
        menuName = CurrentCameraRoutes.ServicePath)]
    public class CurrentCameraAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private CurrentCameraLogSettings _logSettings;
        [SerializeField] [Indent] private CurrentCamera _prefab;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<CurrentCameraLogger>()
                .WithParameter(_logSettings);

            builder.Register<CurrentCamera>()
                .As<ICurrentCamera>()
                .AsCallbackListener();
        }
    }
}