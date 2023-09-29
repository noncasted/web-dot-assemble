using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Dots.Common;
using GamePlay.Level.Dots.Destroyer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Dots.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DotsRoutes.FactoryName,
        menuName = DotsRoutes.FactoryPath)]
    public class DotFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<DotFactory>()
                .As<IDotFactory>();

            services.Register<DotDestroyer>()
                .As<IDotDestroyer>();
        }
    }
}