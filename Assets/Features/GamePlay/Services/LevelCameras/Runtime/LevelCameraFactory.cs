using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.Local.Abstract;
using GamePlay.Services.LevelCameras.Common;
using GamePlay.Services.LevelCameras.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.ServiceName,
        menuName = LevelCameraRoutes.ServicePath)]
    public class LevelCameraFactory : ScriptableObject, ILocalServiceFactory
    {
        [SerializeField] [Indent] private LevelCameraConfigAsset _config;
        [SerializeField] [Indent] private LevelCameraLogSettings _logSettings;
        [SerializeField] [Indent] private LevelCamera _prefab;

        public void Create(IDependencyRegister builder, ILocalUtils utils)
        {
            var levelCamera = Instantiate(_prefab);
            levelCamera.name = "LevelCamera";

            builder.Register<LevelCameraLogger>()
                .WithParameter(_logSettings)
                .AsSelf();

            builder.Register<LevelCameraConfig>()
                .WithParameter(_config)
                .As<ILevelCameraConfig>();

            builder.RegisterComponent(levelCamera)
                .As<ILevelCamera>()
                .AsCallbackListener();

            utils.ServiceBinder.AddToModules(levelCamera);
        }
    }
}