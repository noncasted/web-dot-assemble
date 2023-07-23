using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.UI.EventSystems.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Global.Services.UI.EventSystems.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EventSystemRoutes.ServiceName, menuName = EventSystemRoutes.ServicePath)]
    public class EventSystemFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private EventSystem _prefab;
        
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            var eventSystem = Instantiate(_prefab);
            eventSystem.name = "EventSystem";

            serviceBinder.AddToModules(eventSystem);
        }
    }
}