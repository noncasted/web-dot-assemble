using Common.Architecture.DiContainer.Abstract;
using Global.LevelConfigurations.Avatars;
using Global.Setup.Service;
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
        
        public void Create(IDependencyRegister builder, IGlobalUtils utils)
        {
            builder.Register<Collections>()
                .WithParameter<IAvatarsRegistry>(_registry)
                .As<ICollections>()
                .AsCallbackListener();
        }
    }
}