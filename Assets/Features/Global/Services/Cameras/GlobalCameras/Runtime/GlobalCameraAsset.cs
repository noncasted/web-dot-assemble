using Common.Architecture.DiContainer.Abstract;
using Global.Cameras.GlobalCameras.Common;
using Global.Cameras.GlobalCameras.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.GlobalCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalCameraRoutes.ServiceName,
        menuName = GlobalCameraRoutes.ServicePath)]
    public class GlobalCameraAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private GlobalCameraLogSettings _logSettings;
        [SerializeField] [Indent] private GlobalCamera _prefab;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            var globalCamera = Instantiate(_prefab);
            globalCamera.name = "Camera_Global";
            globalCamera.gameObject.SetActive(false);

            builder.Register<GlobalCameraLogger>()
                .WithParameter(_logSettings);

            builder.RegisterComponent(globalCamera)
                .As<IGlobalCamera>()
                .AsCallbackListener();

            utils.Binder.AddToModules(globalCamera);
        }
    }
}