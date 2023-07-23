using UnityEngine;

namespace Global.Services.Cameras.CurrentCameras.Runtime
{
    public interface ICurrentCamera
    {
        Camera Current { get; }

        void SetCamera(Camera current);
    }
}