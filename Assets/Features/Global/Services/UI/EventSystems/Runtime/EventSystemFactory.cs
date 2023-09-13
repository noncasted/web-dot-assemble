using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Global.UI.EventSystems.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Global.UI.EventSystems.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EventSystemRoutes.ServiceName, menuName = EventSystemRoutes.ServicePath)]
    public class EventSystemFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private EventSystem _prefab;
        
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            var eventSystem = Instantiate(_prefab);
            eventSystem.name = "EventSystem";

            utils.Binder.AddToModules(eventSystem);
        }
    }
}