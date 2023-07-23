using UnityEngine;

namespace Common.Architecture.Local.Services.Abstract
{
    public interface ILocalServiceBinder
    {
        void AddToModules(GameObject service);
        void AddToModules(MonoBehaviour service);
    }
}