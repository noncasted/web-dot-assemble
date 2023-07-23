﻿using UnityEngine;

namespace Global.Services.Cameras.GlobalCameras.Runtime
{
    public interface IGlobalCamera
    {
        Camera Camera { get; }
        void Enable();
        void Disable();
        void EnableListener();
        void DisableListener();
    }
}