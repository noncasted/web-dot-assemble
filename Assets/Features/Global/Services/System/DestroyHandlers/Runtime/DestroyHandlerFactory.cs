using Common.Architecture.DiContainer.Abstract;
using Global.Services.Setup.Service;
using Global.Services.System.DestroyHandlers.Common;
using UnityEngine;

namespace Global.Services.System.DestroyHandlers.Runtime
{
    [CreateAssetMenu(fileName = DestroyHandlerRoutes.ServiceName,
        menuName = DestroyHandlerRoutes.ServicePath)]
    public class DestroyHandlerFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private DestroyHandler _prefab;
        
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            var destroyHandler = Instantiate(_prefab);

            builder.RegisterComponent(destroyHandler)
                .AsCallbackListener();
            
            serviceBinder.AddToModules(destroyHandler);
        }
    }
}