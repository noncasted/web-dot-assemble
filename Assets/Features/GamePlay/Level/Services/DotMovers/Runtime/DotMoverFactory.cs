using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Services.DotMovers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Services.DotMovers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DotMoverRoutes.ServiceName,
        menuName = DotMoverRoutes.ServicePath)]
    public class DotMoverFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private DotMoverConfig _config;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<DotMover>()
                .WithParameter<IDotMoverConfig>(_config)
                .As<IDotMover>();
        }
    }
}