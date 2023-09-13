﻿using Common.Architecture.DiContainer.Abstract;
using Global.Cameras.CurrentCameras.Common;
using Global.Cameras.CurrentCameras.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CurrentCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.ServiceName,
        menuName = CurrentCameraRoutes.ServicePath)]
    public class CurrentCameraAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private CurrentCameraLogSettings _logSettings;

        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<CurrentCameraLogger>()
                .WithParameter(_logSettings);

            builder.Register<CurrentCamera>()
                .As<ICurrentCamera>()
                .AsCallbackListener();
        }
    }
}