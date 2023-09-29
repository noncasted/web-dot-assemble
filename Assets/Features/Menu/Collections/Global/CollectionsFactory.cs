using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.LevelConfigurations.Avatars;
using Menu.Collections.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Collections.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CollectionsRoutes.ServiceName,
        menuName = CollectionsRoutes.ServicePath)]
    public class CollectionsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private AvatarsRegistry _registry;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Collections>()
                .WithParameter<IAvatarsRegistry>(_registry)
                .As<ICollections>()
                .AsCallbackListener();
        }
    }
}