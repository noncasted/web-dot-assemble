using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Services.AssembleCheck.Common;
using GamePlay.Level.Services.AssembleCheck.Factory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Services.AssembleCheck.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AssembleCheckRoutes.FactoryName,
        menuName = AssembleCheckRoutes.FactoryPath)]
    public class AssembleCheckSetup : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<AssembleCheckFactory>()
                .As<IAssembleCheckFactory>();
        }
    }
}