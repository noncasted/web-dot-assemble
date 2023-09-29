using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Services.Score.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Services.Score.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScoreRoutes.ServiceName,
        menuName = ScoreRoutes.ServicePath)]
    public class ScoreFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Score>()
                .As<IScore>();
        }
    }
}