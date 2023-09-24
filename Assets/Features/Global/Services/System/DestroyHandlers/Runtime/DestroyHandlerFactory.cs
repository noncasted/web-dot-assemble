using Common.Architecture.DiContainer.Abstract;
using Global.Setup.Service;
using Global.System.DestroyHandlers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.DestroyHandlers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DestroyHandlerRoutes.ServiceName,
        menuName = DestroyHandlerRoutes.ServicePath)]
    public class DestroyHandlerFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private DestroyHandler _prefab;
        
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            var destroyHandler = Instantiate(_prefab);

            builder.RegisterComponent(destroyHandler)
                .AsCallbackListener();
            
            utils.Binder.AddToModules(destroyHandler);
        }
    }
}