using Common.Architecture.DiContainer.Abstract;
using Global.Services.LevelConfiguration.Avatars;
using Global.Services.Setup.Service;
using Menu.Collections.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Collections.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CollectionsRoutes.ServiceName,
        menuName = CollectionsRoutes.ServicePath)]
    public class CollectionsFactory : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] private AvatarsRegistry _registry;
        
        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<Collections>()
                .WithParameter<IAvatarsRegistry>(_registry)
                .As<ICollections>()
                .AsCallbackListener();
        }
    }
}