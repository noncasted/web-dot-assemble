using UnityEngine;

namespace Global.Services.Setup.Service
{
    public interface IGlobalServiceBinder
    {
        void AddToModules(MonoBehaviour service);
    }
}